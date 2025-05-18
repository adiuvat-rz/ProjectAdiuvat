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
using System.IO;
using System.Windows.Forms;

namespace ProjectAdiuvat
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> filePaths = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        // BuildKey:
        //   Reads and trims the text from the four XOR key textboxes (xor1–xor4),
        //   then concatenates them into a single comma-separated key string.
        //----------------------------------------------------------------------------
        private string BuildKey()
        {
            return $"{xor1.Text.Trim()},{xor2.Text.Trim()},{xor3.Text.Trim()},{xor4.Text.Trim()}";
        }

        //----------------------------------------------------------------------------
        // LogActivity:
        //   Prepends a timestamp to the provided message and appends it to the ListBox
        //   (LB_DISPLAY), then scrolls to the latest entry.
        //----------------------------------------------------------------------------
        private void LogActivity(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LB_DISPLAY.Items.Add($"{timestamp} : {message}");
            LB_DISPLAY.TopIndex = LB_DISPLAY.Items.Count - 1;
        }

        //----------------------------------------------------------------------------
        // LOAD_DEC_FILES_Click:
        //   Opens a multi-select OpenFileDialog for .dec files, adds each newly selected
        //   file to the filePaths dictionary, and logs the count of files loaded.
        //----------------------------------------------------------------------------
        private void LOAD_DEC_FILES_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "DEC Files|*.dec", Multiselect = true })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                int loadedCount = 0;

                foreach (var file in ofd.FileNames)
                {
                    string fileName = Path.GetFileName(file);
                    if (!filePaths.ContainsKey(fileName))
                    {
                        filePaths[fileName] = file;
                        loadedCount++;
                    }
                }

                LogActivity($"{loadedCount} .dec file(s) loaded successfully.");
            }
        }

        //----------------------------------------------------------------------------
        // LOAD_ENC_FILES_Click:
        //   Opens a multi-select OpenFileDialog for .enc files, adds each newly selected
        //   file to the filePaths dictionary, and logs the count of files loaded.
        //----------------------------------------------------------------------------
        private void LOAD_ENC_FILES_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "ENC Files|*.enc", Multiselect = true })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                int loadedCount = 0;

                foreach (var file in ofd.FileNames)
                {
                    string fileName = Path.GetFileName(file);
                    if (!filePaths.ContainsKey(fileName))
                    {
                        filePaths[fileName] = file;
                        loadedCount++;
                    }
                }

                LogActivity($"{loadedCount} .enc file(s) loaded successfully.");
            }
        }

        //----------------------------------------------------------------------------
        // UpdateProgressBar:
        //   Calculates and sets the progress bar value based on the ratio of `current`
        //   to `total`, then refreshes the control to immediately reflect the change.
        //----------------------------------------------------------------------------
        private void UpdateProgressBar(int current, int total)
        {
            progressBar1.Value = (int)((current / (double)total) * 100);
            progressBar1.Refresh();
        }

        //----------------------------------------------------------------------------
        // BTN_DEFLATE_Click:
        //   Validates that .dec files are loaded, initializes the progress bar,
        //   builds the XOR key and compression level, then iterates through all
        //   loaded files to compress each via the native DLL. Logs success or error
        //   for each file, updates the progress bar, clears the file list, and
        //   logs completion.
        //----------------------------------------------------------------------------
        private void BTN_DEFLATE_Click(object sender, EventArgs e)
        {
            if (filePaths.Count == 0)
            {
                MessageBox.Show("No files loaded. Please load .dec files first.", "Empty File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            string key = BuildKey();
            if (!int.TryParse(txtLevel.Text, out int level) || level < 1 || level > 9)
                level = 1;

            int processed = 0;
            int total = filePaths.Count;

            foreach (var pair in filePaths)
            {
                string sourceFile = pair.Value;
                string outPath = Path.ChangeExtension(sourceFile, ".enc");

                int result = NativeMethods.CompressFilePathEx(sourceFile, outPath, key, level);

                LogActivity(result == 0
                    ? $"{pair.Key} compressed successfully."
                    : $"Compression failed for {pair.Key} (code {result}).");

                processed++;
                UpdateProgressBar(processed, total);
            }

            filePaths.Clear();
            LogActivity("Compression task completed.");
        }

        //----------------------------------------------------------------------------
        // BTN_INFLATE_Click:
        //   Validates that .enc files are loaded, resets and initializes the progress bar,
        //   builds the XOR key, then iterates through all loaded files to decompress each via
        //   the native DLL. Logs success or error for each file, updates the progress bar,
        //   clears the file list, and logs completion.
        //----------------------------------------------------------------------------
        private void BTN_INFLATE_Click(object sender, EventArgs e)
        {
            if (filePaths.Count == 0)
            {
                MessageBox.Show("No files loaded. Please load .enc files first.", "Empty File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            string key = BuildKey();

            int processed = 0;
            int total = filePaths.Count;

            foreach (var pair in filePaths)
            {
                string sourceFile = pair.Value;
                string outPath = Path.ChangeExtension(sourceFile, ".dec");

                int result = NativeMethods.DecompressFilePathEx(sourceFile, outPath, key);

                LogActivity(result == 0
                    ? $"{pair.Key} decompressed successfully."
                    : $"Decompression failed for {pair.Key} (code {result}).");

                processed++;
                UpdateProgressBar(processed, total);
            }

            filePaths.Clear();
            LogActivity("Decompression task completed.");
        }

        //----------------------------------------------------------------------------
        // CLEAR_LISTBOX_Click:
        //   Clears the activity log ListBox and resets the progress bar. If no files
        //   are loaded, it still clears the log and bar, then shows a warning message.
        //   Otherwise, it also clears the internal filePaths dictionary and logs the
        //   "Activity log cleared." entry.
        //----------------------------------------------------------------------------
        private void CLEAR_LISTBOX_Click(object sender, EventArgs e)
        {
            if (filePaths.Count == 0)
            {
                LB_DISPLAY.Items.Clear();
                progressBar1.Value = 0;
                MessageBox.Show("No files loaded.", "Empty File List",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LB_DISPLAY.Items.Clear();
            filePaths.Clear();
            progressBar1.Value = 0;
            LogActivity("Activity log cleared.");
        }
    }
}
