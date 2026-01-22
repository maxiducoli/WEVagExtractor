namespace VagExtractor
{
    partial class frmVagExtractor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIso = new Button();
            groupBox1 = new GroupBox();
            lblIsoPath = new Label();
            rbWAV = new RadioButton();
            rbVAG = new RadioButton();
            btnFolder = new Button();
            label1 = new Label();
            lstFiles = new ListBox();
            progressBar1 = new ProgressBar();
            LBLMensaje = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIso
            // 
            btnIso.Enabled = false;
            btnIso.Image = VagExtractor.Properties.Resources.CD_ROM;
            btnIso.Location = new Point(15, 279);
            btnIso.Name = "btnIso";
            btnIso.Size = new Size(40, 40);
            btnIso.TabIndex = 0;
            btnIso.UseVisualStyleBackColor = true;
            btnIso.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblIsoPath);
            groupBox1.Controls.Add(rbWAV);
            groupBox1.Controls.Add(rbVAG);
            groupBox1.Controls.Add(btnFolder);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnIso);
            groupBox1.Controls.Add(lstFiles);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 366);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "VAG extractor";
            // 
            // lblIsoPath
            // 
            lblIsoPath.Location = new Point(15, 322);
            lblIsoPath.Name = "lblIsoPath";
            lblIsoPath.Size = new Size(269, 41);
            lblIsoPath.TabIndex = 8;
            // 
            // rbWAV
            // 
            rbWAV.AutoSize = true;
            rbWAV.Enabled = false;
            rbWAV.Location = new Point(119, 300);
            rbWAV.Name = "rbWAV";
            rbWAV.Size = new Size(50, 19);
            rbWAV.TabIndex = 7;
            rbWAV.TabStop = true;
            rbWAV.Text = "WAV";
            rbWAV.UseVisualStyleBackColor = true;
            rbWAV.CheckedChanged += rbWAV_CheckedChanged;
            // 
            // rbVAG
            // 
            rbVAG.AutoSize = true;
            rbVAG.Enabled = false;
            rbVAG.Location = new Point(119, 279);
            rbVAG.Name = "rbVAG";
            rbVAG.Size = new Size(47, 19);
            rbVAG.TabIndex = 6;
            rbVAG.TabStop = true;
            rbVAG.Text = "VAG";
            rbVAG.UseVisualStyleBackColor = true;
            rbVAG.CheckedChanged += rbVAG_CheckedChanged;
            // 
            // btnFolder
            // 
            btnFolder.Enabled = false;
            btnFolder.Image = VagExtractor.Properties.Resources.Folder;
            btnFolder.Location = new Point(244, 279);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(40, 40);
            btnFolder.TabIndex = 5;
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 24);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 4;
            label1.Text = "Choose RA file";
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 15;
            lstFiles.Items.AddRange(new object[] { "W2002J00.RA", "W2002J10.RA", "W2002J11.RA", "W2002J12.RA", "W2002J60.RA", "W2002J61.RA", "W2002J62.RA", "W2002J63.RA", "W2002J64.RA", "W2002J65.RA", "W2002J70.RA", "W2002J71.RA", "W2002J72.RA", "W2002J73.RA", "W2002J74.RA" });
            lstFiles.Location = new Point(15, 44);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(269, 229);
            lstFiles.TabIndex = 3;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 384);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(301, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 4;
            // 
            // LBLMensaje
            // 
            LBLMensaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LBLMensaje.ForeColor = Color.FromArgb(192, 0, 0);
            LBLMensaje.Location = new Point(12, 384);
            LBLMensaje.Name = "LBLMensaje";
            LBLMensaje.Size = new Size(301, 29);
            LBLMensaje.TabIndex = 9;
            // 
            // frmVagExtractor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 417);
            Controls.Add(LBLMensaje);
            Controls.Add(progressBar1);
            Controls.Add(groupBox1);
            Name = "frmVagExtractor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "By -= CARP =- @maxiducoli";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIso;
        private GroupBox groupBox1;
        private Button btnFolder;
        private Label label1;
        private ListBox lstFiles;
        private RadioButton rbWAV;
        private RadioButton rbVAG;
        private Label lblIsoPath;
        private ProgressBar progressBar1;
        private Label LBLMensaje;
    }
}
