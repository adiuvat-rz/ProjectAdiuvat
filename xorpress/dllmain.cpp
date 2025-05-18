/*
 * Project: XORPress
 * Description: Library and CLI for compressing and decompressing files using raw DEFLATE combined with a 4-byte XOR key.
 *              Provides functions to parse a comma-separated hex key, apply XOR obfuscation to the first bytes of the stream,
 *              and handle file I/O both at the stream level and via convenient path-based wrappers.
 * Ragezone:   https://forum.ragezone.com/members/adiuvat.2000378669/
 * GitHub:     https://github.com/adiuvat-rz
 * Contributed to the RZ Community.
 * © 2025 adiuvat-rz. All rights reserved.
 */

#include "pch.h"

#include <cstdio>
#include <sys/stat.h>
#include <zlib.h>
#include <string>
#include <sstream>
#include <cassert>

#define CHUNK      16384
#define MAX_WBITS  15

 //----------------------------------------------------------------------------
 // Parses a comma-separated wide-string of exactly four hex byte pairs
 // (e.g. L"5A, 2E, 98, CE"), trims whitespace around each token, converts
 // each from hex to a byte, and stores them in `out[0]` through `out[3]`.
 // Returns true on success; false if there aren’t exactly four tokens,
 // if any token is empty after trimming, or if conversion fails.
 //----------------------------------------------------------------------------
static bool ParseKey(const std::wstring& txt, unsigned char out[4]) {
    std::wistringstream ss(txt);
    std::wstring token;
    for (int i = 0; i < 4; ++i) {
        if (!std::getline(ss, token, L',')) return false;
        auto start = token.find_first_not_of(L" \t");
        auto end = token.find_last_not_of(L" \t");
        if (start == std::wstring::npos) return false;
        token = token.substr(start, end - start + 1);

        unsigned long val = std::stoul(token, nullptr, 16);
        out[i] = static_cast<unsigned char>(val & 0xFF);
    }
    return true;
}

//----------------------------------------------------------------------------
// CompressFileWithKey:
//   Reads all data from `source`, writes a 4-byte original-size header to `dest`,
//   then compresses the data using raw DEFLATE at the specified `level`.
//   After compression, it XORs the first four output bytes with `key[]`
//   (cycling through the key for the very first 4 bytes only), and streams
//   the result to `dest`. Returns Z_OK on success or a zlib error code.
//----------------------------------------------------------------------------
static int CompressFileWithKey(FILE* source, FILE* dest, const unsigned char key[4], int level) {
    z_stream strm = {};
    unsigned long indx = 0;
    struct _stat sb;

    if (_fstat(_fileno(source), &sb) < 0) return Z_ERRNO;
    unsigned long origSize = (unsigned long)sb.st_size;
    if (fwrite(&origSize, 4, 1, dest) != 1 || ferror(dest))
        return Z_ERRNO;

    int ret = deflateInit2(&strm, level, Z_DEFLATED, -MAX_WBITS, 8, Z_DEFAULT_STRATEGY);
    if (ret != Z_OK) return ret;

    unsigned char* in = (unsigned char*)std::malloc(CHUNK);
    unsigned char* out = (unsigned char*)std::malloc(CHUNK);
    if (!in || !out) { deflateEnd(&strm); std::free(in); std::free(out); return Z_MEM_ERROR; }

    int flush;
    do {
        strm.avail_in = (uInt)fread(in, 1, CHUNK, source);
        if (ferror(source)) { ret = Z_ERRNO; break; }
        flush = feof(source) ? Z_FINISH : Z_NO_FLUSH;
        strm.next_in = in;

        do {
            strm.avail_out = CHUNK;
            strm.next_out = out;
            ret = deflate(&strm, flush);
            assert(ret != Z_STREAM_ERROR);

            unsigned have = CHUNK - strm.avail_out;
            for (unsigned i = 0; i < have && indx < 4; ++i, ++indx) {
                out[i] ^= key[indx];
            }
            if (fwrite(out, 1, have, dest) != have || ferror(dest)) { ret = Z_ERRNO; break; }
        } while (strm.avail_out == 0 && ret == Z_OK);

    } while (flush != Z_FINISH && ret == Z_OK);

    deflateEnd(&strm);
    std::free(in);
    std::free(out);
    return (ret == Z_STREAM_END ? Z_OK : ret);
}

//----------------------------------------------------------------------------
// DecompressFileWithKey:
//   Reads the 4-byte XOR-encrypted header from `source` (decrypting with `key`),
//   then inflates the remaining raw DEFLATE stream and writes the decompressed
//   data to `dest`. Returns Z_OK on successful completion or a zlib/file I/O error.
//----------------------------------------------------------------------------
static int DecompressFileWithKey(FILE* source, FILE* dest, const unsigned char key[4]) {
    z_stream strm = {};
    unsigned long indx = 0;

    unsigned char* in = (unsigned char*)std::malloc(CHUNK);
    unsigned char* out = (unsigned char*)std::malloc(CHUNK);
    if (!in || !out) { std::free(in); std::free(out); return Z_MEM_ERROR; }

    if (fread(in, 1, 4, source) != 4 || ferror(source)) { std::free(in); std::free(out); return Z_ERRNO; }

    int ret = inflateInit2(&strm, -MAX_WBITS);
    if (ret != Z_OK) { std::free(in); std::free(out); return ret; }

    do {
        strm.avail_in = (uInt)fread(in, 1, CHUNK, source);
        if (ferror(source)) { ret = Z_ERRNO; break; }
        if (strm.avail_in == 0) break;

        for (unsigned i = 0; i < strm.avail_in && indx < 4; ++i, ++indx) {
            in[i] ^= key[indx];
        }
        strm.next_in = in;

        do {
            strm.avail_out = CHUNK;
            strm.next_out = out;
            ret = inflate(&strm, Z_NO_FLUSH);
            assert(ret != Z_STREAM_ERROR);
            if (ret == Z_NEED_DICT || ret == Z_DATA_ERROR || ret == Z_MEM_ERROR) { break; }
            unsigned have = CHUNK - strm.avail_out;
            if (fwrite(out, 1, have, dest) != have || ferror(dest)) { ret = Z_ERRNO; break; }
        } while (strm.avail_out == 0 && ret == Z_OK);

    } while (ret != Z_STREAM_END);

    inflateEnd(&strm);
    std::free(in);
    std::free(out);
    return (ret == Z_STREAM_END ? Z_OK : ret);
}

//----------------------------------------------------------------------------
// CompressFilePathEx:
//   Parses the comma-separated hex key string `keyTxt` into a 4-byte key,
//   opens `sourceFile` for reading and `destFile` for writing, and then
//   calls CompressFileWithKey to perform compression + XOR. Returns the
//   zlib or I/O error code produced by the compression.
//----------------------------------------------------------------------------
int CompressFilePathEx(
    const wchar_t* sourceFile,
    const wchar_t* destFile,
    const wchar_t* keyTxt,
    int level
) {
    unsigned char key[4];
    if (!ParseKey(keyTxt, key)) return Z_STREAM_ERROR;
    FILE* fi = nullptr; FILE* fo = nullptr;
    if (_wfopen_s(&fi, sourceFile, L"rb") || _wfopen_s(&fo, destFile, L"wb")) {
        if (fi) fclose(fi);
        return Z_ERRNO;
    }
    int r = CompressFileWithKey(fi, fo, key, level);
    fclose(fi); fclose(fo);
    return r;
}

//----------------------------------------------------------------------------
// DecompressFilePathEx:
//   Parses the comma-separated hex key string `keyTxt` into a 4-byte key,
//   opens `sourceFile` for reading and `destFile` for writing, and then
//   calls DecompressFileWithKey to perform XOR-decryption + decompression.
//   Returns the zlib or I/O error code produced by the decompression.
//----------------------------------------------------------------------------
int DecompressFilePathEx(
    const wchar_t* sourceFile,
    const wchar_t* destFile,
    const wchar_t* keyTxt
) {
    unsigned char key[4];
    if (!ParseKey(keyTxt, key)) return Z_STREAM_ERROR;
    FILE* fi = nullptr; FILE* fo = nullptr;
    if (_wfopen_s(&fi, sourceFile, L"rb") || _wfopen_s(&fo, destFile, L"wb")) {
        if (fi) fclose(fi);
        return Z_ERRNO;
    }
    int r = DecompressFileWithKey(fi, fo, key);
    fclose(fi); fclose(fo);
    return r;
}

//----------------------------------------------------------------------------
// DllMain:
//   Entry point for the DLL, called by the system when a process or thread
//   attaches to or detaches from the DLL. ul_reason_for_call indicates the
//   event (process/thread attach/detach). Currently no action is taken on
//   any event, and the function always returns TRUE to indicate successful load.
//----------------------------------------------------------------------------
BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved)
{
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
