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

namespace ProjectAdiuvat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CLEAR_LISTBOX = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.xor4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xor3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xor2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.Label();
            this.BTN_INFLATE = new System.Windows.Forms.Button();
            this.BTN_DEFLATE = new System.Windows.Forms.Button();
            this.LOAD_DEC_FILES = new System.Windows.Forms.Button();
            this.LOAD_ENC_FILES = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xor1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_DISPLAY = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CLEAR_LISTBOX);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtLevel);
            this.panel1.Controls.Add(this.BTN_INFLATE);
            this.panel1.Controls.Add(this.BTN_DEFLATE);
            this.panel1.Controls.Add(this.LOAD_DEC_FILES);
            this.panel1.Controls.Add(this.LOAD_ENC_FILES);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.LB_DISPLAY);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 379);
            this.panel1.TabIndex = 0;
            // 
            // CLEAR_LISTBOX
            // 
            this.CLEAR_LISTBOX.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLEAR_LISTBOX.Location = new System.Drawing.Point(416, 221);
            this.CLEAR_LISTBOX.Name = "CLEAR_LISTBOX";
            this.CLEAR_LISTBOX.Size = new System.Drawing.Size(72, 24);
            this.CLEAR_LISTBOX.TabIndex = 13;
            this.CLEAR_LISTBOX.Text = "Clear";
            this.CLEAR_LISTBOX.UseVisualStyleBackColor = true;
            this.CLEAR_LISTBOX.Click += new System.EventHandler(this.CLEAR_LISTBOX_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.xor4);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(404, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(87, 62);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4TH";
            // 
            // xor4
            // 
            this.xor4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xor4.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xor4.ForeColor = System.Drawing.Color.SeaGreen;
            this.xor4.Location = new System.Drawing.Point(43, 16);
            this.xor4.Margin = new System.Windows.Forms.Padding(0);
            this.xor4.MaxLength = 2;
            this.xor4.Name = "xor4";
            this.xor4.Size = new System.Drawing.Size(36, 34);
            this.xor4.TabIndex = 9;
            this.xor4.Text = "3A";
            this.xor4.WordWrap = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(4, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "0x";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.xor3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(311, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(87, 62);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3RD";
            // 
            // xor3
            // 
            this.xor3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xor3.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xor3.ForeColor = System.Drawing.Color.SeaGreen;
            this.xor3.Location = new System.Drawing.Point(42, 17);
            this.xor3.Margin = new System.Windows.Forms.Padding(0);
            this.xor3.MaxLength = 2;
            this.xor3.Name = "xor3";
            this.xor3.Size = new System.Drawing.Size(36, 34);
            this.xor3.TabIndex = 7;
            this.xor3.Text = "7B";
            this.xor3.WordWrap = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 35);
            this.label3.TabIndex = 6;
            this.label3.Text = "0x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xor2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(219, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(87, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2ND";
            // 
            // xor2
            // 
            this.xor2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xor2.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xor2.ForeColor = System.Drawing.Color.SeaGreen;
            this.xor2.Location = new System.Drawing.Point(44, 16);
            this.xor2.Margin = new System.Windows.Forms.Padding(0);
            this.xor2.MaxLength = 2;
            this.xor2.Name = "xor2";
            this.xor2.Size = new System.Drawing.Size(36, 34);
            this.xor2.TabIndex = 5;
            this.xor2.Text = "19";
            this.xor2.WordWrap = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "0x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(118, 200);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(382, 16);
            this.progressBar1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(362, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Packing Intensity :";
            // 
            // txtLevel
            // 
            this.txtLevel.AutoSize = true;
            this.txtLevel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevel.Location = new System.Drawing.Point(482, 363);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(14, 16);
            this.txtLevel.TabIndex = 7;
            this.txtLevel.Text = "1";
            // 
            // BTN_INFLATE
            // 
            this.BTN_INFLATE.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_INFLATE.ForeColor = System.Drawing.Color.Chocolate;
            this.BTN_INFLATE.Location = new System.Drawing.Point(124, 311);
            this.BTN_INFLATE.Name = "BTN_INFLATE";
            this.BTN_INFLATE.Size = new System.Drawing.Size(182, 43);
            this.BTN_INFLATE.TabIndex = 6;
            this.BTN_INFLATE.Text = "Inflate";
            this.BTN_INFLATE.UseVisualStyleBackColor = true;
            this.BTN_INFLATE.Click += new System.EventHandler(this.BTN_INFLATE_Click);
            // 
            // BTN_DEFLATE
            // 
            this.BTN_DEFLATE.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DEFLATE.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.BTN_DEFLATE.Location = new System.Drawing.Point(312, 311);
            this.BTN_DEFLATE.Name = "BTN_DEFLATE";
            this.BTN_DEFLATE.Size = new System.Drawing.Size(179, 43);
            this.BTN_DEFLATE.TabIndex = 5;
            this.BTN_DEFLATE.Text = "Deflate";
            this.BTN_DEFLATE.UseVisualStyleBackColor = true;
            this.BTN_DEFLATE.Click += new System.EventHandler(this.BTN_DEFLATE_Click);
            // 
            // LOAD_DEC_FILES
            // 
            this.LOAD_DEC_FILES.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LOAD_DEC_FILES.FlatAppearance.BorderSize = 0;
            this.LOAD_DEC_FILES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.LOAD_DEC_FILES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOAD_DEC_FILES.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOAD_DEC_FILES.Location = new System.Drawing.Point(272, 221);
            this.LOAD_DEC_FILES.Margin = new System.Windows.Forms.Padding(0);
            this.LOAD_DEC_FILES.Name = "LOAD_DEC_FILES";
            this.LOAD_DEC_FILES.Size = new System.Drawing.Size(138, 24);
            this.LOAD_DEC_FILES.TabIndex = 4;
            this.LOAD_DEC_FILES.Text = "Load .dec files";
            this.LOAD_DEC_FILES.UseVisualStyleBackColor = false;
            this.LOAD_DEC_FILES.Click += new System.EventHandler(this.LOAD_DEC_FILES_Click);
            // 
            // LOAD_ENC_FILES
            // 
            this.LOAD_ENC_FILES.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LOAD_ENC_FILES.FlatAppearance.BorderSize = 0;
            this.LOAD_ENC_FILES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.LOAD_ENC_FILES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOAD_ENC_FILES.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOAD_ENC_FILES.Location = new System.Drawing.Point(127, 222);
            this.LOAD_ENC_FILES.Margin = new System.Windows.Forms.Padding(0);
            this.LOAD_ENC_FILES.Name = "LOAD_ENC_FILES";
            this.LOAD_ENC_FILES.Size = new System.Drawing.Size(132, 23);
            this.LOAD_ENC_FILES.TabIndex = 3;
            this.LOAD_ENC_FILES.Text = "Load .enc files";
            this.LOAD_ENC_FILES.UseVisualStyleBackColor = false;
            this.LOAD_ENC_FILES.Click += new System.EventHandler(this.LOAD_ENC_FILES_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xor1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(126, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1ST";
            // 
            // xor1
            // 
            this.xor1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xor1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xor1.ForeColor = System.Drawing.Color.SeaGreen;
            this.xor1.Location = new System.Drawing.Point(43, 17);
            this.xor1.Margin = new System.Windows.Forms.Padding(0);
            this.xor1.MaxLength = 2;
            this.xor1.Name = "xor1";
            this.xor1.Size = new System.Drawing.Size(36, 34);
            this.xor1.TabIndex = 3;
            this.xor1.Text = "86";
            this.xor1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "0x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LB_DISPLAY
            // 
            this.LB_DISPLAY.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_DISPLAY.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_DISPLAY.FormattingEnabled = true;
            this.LB_DISPLAY.ItemHeight = 14;
            this.LB_DISPLAY.Location = new System.Drawing.Point(118, 0);
            this.LB_DISPLAY.Name = "LB_DISPLAY";
            this.LB_DISPLAY.Size = new System.Drawing.Size(382, 200);
            this.LB_DISPLAY.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 379);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 379);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "XORPress - By: Adiuvat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox LB_DISPLAY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox xor1;
        private System.Windows.Forms.TextBox xor4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xor3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xor2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_INFLATE;
        private System.Windows.Forms.Button BTN_DEFLATE;
        private System.Windows.Forms.Button LOAD_DEC_FILES;
        private System.Windows.Forms.Button LOAD_ENC_FILES;
        private System.Windows.Forms.Label txtLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CLEAR_LISTBOX;
    }
}

