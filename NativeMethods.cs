/*
 * Project: ProjectAdiuvat
 * Description: Windows Forms front-end for the XORPress compression library.  
 *              Provides UI controls to load .dec/.enc files, enter a 4-byte XOR key
 *              and compression level, then batch compress or decompress files via
 *              the native DLL. Features include timestamped activity logging and
 *              a progress bar to track operations.
 * Ragezone: https://forum.ragezone.com/members/adiuvat.2000378669/
 * GitHub:   https://github.com/adiuvat-rz
 * Contributed to the RZ Community.
 * © 2025 adiuvat-rz. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAdiuvat
{
    static class NativeMethods
    {
        //----------------------------------------------------------------------------
        // CompressFilePathEx:
        //   P/Invoke declaration for the native function that compresses the file at
        //   `sourceFile` to `destFile` using the comma-separated hex key string `keyTxt`
        //   and the specified compression `level`. Returns Z_OK (0) on success or a zlib/I/O error code.
        //----------------------------------------------------------------------------
        [DllImport("xorpress.dll",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int CompressFilePathEx(
            string sourceFile,
            string destFile,
            string keyTxt,
            int level);

        //----------------------------------------------------------------------------
        // DecompressFilePathEx:
        //   P/Invoke declaration for the native function that decompresses the file at
        //   `sourceFile` to `destFile` using the comma-separated hex key string `keyTxt`.
        //   Returns Z_OK (0) on success or a zlib/I/O error code.
        //----------------------------------------------------------------------------
        [DllImport("xorpress.dll",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int DecompressFilePathEx(
            string sourceFile,
            string destFile,
            string keyTxt);
    }
}
