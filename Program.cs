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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAdiuvat
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
