// pch.h: This is a precompiled header file.
// Files listed below are compiled only once, improving build performance for future builds.
// This also affects IntelliSense performance, including code completion and many code browsing features.
// However, files listed here are ALL re-compiled if any one of them is updated between builds.
// Do not add files here that you will be updating frequently as this negates the performance advantage.

#ifndef PCH_H
#define PCH_H

// add headers that you want to pre-compile here
#include <Windows.h>

#ifdef __cplusplus
extern "C" {
#endif

    // Compresses the file at `sourceFile`, writing output to `destFile`.
    // `keyTxt` is a null-terminated wide string of the form L"AA,BB,CC,DD" (hex pairs always).
    // `level` is compression level 1-9.
    // Returns Z_OK on success or zlib error codes / Z_ERRNO on I/O error.
    __declspec(dllexport) int CompressFilePathEx(
        const wchar_t* sourceFile,
        const wchar_t* destFile,
        const wchar_t* keyTxt,
        int level
    );

    // Decompresses the file at `sourceFile`, writing output to `destFile`.
    // `keyTxt` same format as above.
    __declspec(dllexport) int DecompressFilePathEx(
        const wchar_t* sourceFile,
        const wchar_t* destFile,
        const wchar_t* keyTxt
    );

#ifdef __cplusplus
}
#endif

#endif //PCH_H
