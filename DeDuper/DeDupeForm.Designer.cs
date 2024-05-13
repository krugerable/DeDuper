namespace DeDuper
{
    partial class DeDupeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeDupeForm));
            dgvDuplicates = new DataGridView();
            butChooseDirectory = new Button();
            fbdFolder = new FolderBrowserDialog();
            tbarThreshold = new TrackBar();
            butScan = new Button();
            pBarScan = new ProgressBar();
            PreviewSelectedImage = new PictureBox();
            //Dvgvg = new Subro.Controls.DataGridViewGrouper(components);
            butGroup = new Button();
            rbAvHash = new RadioButton();
            gbAlgoSelection = new GroupBox();
            rbFbComp = new RadioButton();
            rbDifHash = new RadioButton();
            rbPixComp = new RadioButton();
            rbPHash = new RadioButton();
            butMethodSelection = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDuplicates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbarThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviewSelectedImage).BeginInit();
            gbAlgoSelection.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDuplicates
            // 
            dgvDuplicates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDuplicates.Location = new Point(12, 112);
            dgvDuplicates.Name = "dgvDuplicates";
            dgvDuplicates.Size = new Size(776, 553);
            dgvDuplicates.TabIndex = 0;
            dgvDuplicates.RowEnter += dgvDuplicates_RowEnter;
            // 
            // butChooseDirectory
            // 
            butChooseDirectory.Location = new Point(12, 12);
            butChooseDirectory.Name = "butChooseDirectory";
            butChooseDirectory.Size = new Size(110, 45);
            butChooseDirectory.TabIndex = 1;
            butChooseDirectory.Text = "Choose directory";
            butChooseDirectory.UseVisualStyleBackColor = true;
            butChooseDirectory.Click += ButChooseDirectory_Click;
            // 
            // tbarThreshold
            // 
            tbarThreshold.LargeChange = 20;
            tbarThreshold.Location = new Point(498, 12);
            tbarThreshold.Maximum = 100;
            tbarThreshold.Minimum = 1;
            tbarThreshold.Name = "tbarThreshold";
            tbarThreshold.Size = new Size(290, 45);
            tbarThreshold.SmallChange = 10;
            tbarThreshold.TabIndex = 2;
            tbarThreshold.TickFrequency = 5;
            tbarThreshold.Value = 50;
            tbarThreshold.MouseUp += TbarThreshold_MouseUp;
            // 
            // butScan
            // 
            butScan.Location = new Point(128, 12);
            butScan.Name = "butScan";
            butScan.Size = new Size(124, 45);
            butScan.TabIndex = 3;
            butScan.Text = "Scan";
            butScan.UseVisualStyleBackColor = true;
            butScan.Click += ButScan_Click;
            // 
            // pBarScan
            // 
            pBarScan.Location = new Point(794, 12);
            pBarScan.Name = "pBarScan";
            pBarScan.Size = new Size(355, 45);
            pBarScan.TabIndex = 4;
            // 
            // PreviewSelectedImage
            // 
            PreviewSelectedImage.Location = new Point(794, 112);
            PreviewSelectedImage.Name = "PreviewSelectedImage";
            PreviewSelectedImage.Size = new Size(355, 240);
            PreviewSelectedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            PreviewSelectedImage.TabIndex = 5;
            PreviewSelectedImage.TabStop = false;
            // 
            // Dvgvg
            // 
            //Dvgvg.DataGridView = dgvDuplicates;
            //Dvgvg.Options = (Subro.Controls.GroupingOptions)resources.GetObject("Dvgvg.Options");
            // 
            // butGroup
            // 
            butGroup.Location = new Point(378, 12);
            butGroup.Name = "butGroup";
            butGroup.Size = new Size(114, 45);
            butGroup.TabIndex = 6;
            butGroup.Text = "Group";
            butGroup.UseVisualStyleBackColor = true;
            butGroup.Click += butGroup_Click;
            // 
            // rbAvHash
            // 
            rbAvHash.AutoSize = true;
            rbAvHash.Location = new Point(6, 18);
            rbAvHash.Name = "rbAvHash";
            rbAvHash.Size = new Size(115, 19);
            rbAvHash.TabIndex = 7;
            rbAvHash.Tag = "1";
            rbAvHash.Text = "Average Hashing";
            rbAvHash.UseVisualStyleBackColor = true;
            // 
            // gbAlgoSelection
            // 
            gbAlgoSelection.Controls.Add(rbFbComp);
            gbAlgoSelection.Controls.Add(rbDifHash);
            gbAlgoSelection.Controls.Add(rbPixComp);
            gbAlgoSelection.Controls.Add(rbPHash);
            gbAlgoSelection.Controls.Add(rbAvHash);
            gbAlgoSelection.Location = new Point(12, 63);
            gbAlgoSelection.Name = "gbAlgoSelection";
            gbAlgoSelection.Size = new Size(776, 43);
            gbAlgoSelection.TabIndex = 8;
            gbAlgoSelection.TabStop = false;
            gbAlgoSelection.Text = "Detection method selection";
            // 
            // rbFbComp
            // 
            rbFbComp.AutoSize = true;
            rbFbComp.Location = new Point(562, 18);
            rbFbComp.Name = "rbFbComp";
            rbFbComp.Size = new Size(168, 19);
            rbFbComp.TabIndex = 11;
            rbFbComp.Tag = "5";
            rbFbComp.Text = "Feature-based Comparison";
            rbFbComp.UseVisualStyleBackColor = true;
            // 
            // rbDifHash
            // 
            rbDifHash.AutoSize = true;
            rbDifHash.Location = new Point(270, 18);
            rbDifHash.Name = "rbDifHash";
            rbDifHash.Size = new Size(126, 19);
            rbDifHash.TabIndex = 10;
            rbDifHash.Tag = "3";
            rbDifHash.Text = "Difference Hashing";
            rbDifHash.UseVisualStyleBackColor = true;
            // 
            // rbPixComp
            // 
            rbPixComp.AutoSize = true;
            rbPixComp.Location = new Point(402, 18);
            rbPixComp.Name = "rbPixComp";
            rbPixComp.Size = new Size(154, 19);
            rbPixComp.TabIndex = 9;
            rbPixComp.Tag = "4";
            rbPixComp.Text = "Pixel-based Comparison";
            rbPixComp.UseVisualStyleBackColor = true;
            // 
            // rbPHash
            // 
            rbPHash.AutoSize = true;
            rbPHash.Checked = true;
            rbPHash.Location = new Point(136, 18);
            rbPHash.Name = "rbPHash";
            rbPHash.Size = new Size(128, 19);
            rbPHash.TabIndex = 8;
            rbPHash.TabStop = true;
            rbPHash.Tag = "2";
            rbPHash.Text = "Perceptual Hashing";
            rbPHash.UseVisualStyleBackColor = true;
            // 
            // butMethodSelection
            // 
            butMethodSelection.Location = new Point(258, 12);
            butMethodSelection.Name = "butMethodSelection";
            butMethodSelection.Size = new Size(114, 45);
            butMethodSelection.TabIndex = 9;
            butMethodSelection.Text = "Method Scan";
            butMethodSelection.UseVisualStyleBackColor = true;
            butMethodSelection.Click += butMethodSelection_Click;
            // 
            // DeDupeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 677);
            Controls.Add(butMethodSelection);
            Controls.Add(gbAlgoSelection);
            Controls.Add(butGroup);
            Controls.Add(PreviewSelectedImage);
            Controls.Add(pBarScan);
            Controls.Add(butScan);
            Controls.Add(tbarThreshold);
            Controls.Add(butChooseDirectory);
            Controls.Add(dgvDuplicates);
            Name = "DeDupeForm";
            Text = "Dedupe";
            Load += DeDupeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDuplicates).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbarThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviewSelectedImage).EndInit();
            gbAlgoSelection.ResumeLayout(false);
            gbAlgoSelection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDuplicates;
        private Button butChooseDirectory;
        private FolderBrowserDialog fbdFolder;
        private TrackBar tbarThreshold;
        private Button butScan;
        private ProgressBar pBarScan;
        private PictureBox PreviewSelectedImage;
        private Button butGroup;
        private RadioButton rbAvHash;
        private GroupBox gbAlgoSelection;
        private RadioButton rbDifHash;
        private RadioButton rbPixComp;
        private RadioButton rbPHash;
        private RadioButton rbFbComp;
        private Button butMethodSelection;
    }
}