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
            Dvgvg = new Subro.Controls.DataGridViewGrouper(components);
            butGroup = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDuplicates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbarThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviewSelectedImage).BeginInit();
            SuspendLayout();
            // 
            // dgvDuplicates
            // 
            dgvDuplicates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDuplicates.Location = new Point(12, 63);
            dgvDuplicates.Name = "dgvDuplicates";
            dgvDuplicates.Size = new Size(776, 243);
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
            tbarThreshold.Location = new Point(378, 12);
            tbarThreshold.Maximum = 100;
            tbarThreshold.Minimum = 1;
            tbarThreshold.Name = "tbarThreshold";
            tbarThreshold.Size = new Size(308, 45);
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
            pBarScan.Location = new Point(692, 12);
            pBarScan.Name = "pBarScan";
            pBarScan.Size = new Size(96, 45);
            pBarScan.TabIndex = 4;
            // 
            // PreviewSelectedImage
            // 
            PreviewSelectedImage.Location = new Point(12, 312);
            PreviewSelectedImage.Name = "PreviewSelectedImage";
            PreviewSelectedImage.Size = new Size(776, 353);
            PreviewSelectedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            PreviewSelectedImage.TabIndex = 5;
            PreviewSelectedImage.TabStop = false;
            // 
            // Dvgvg
            // 
            Dvgvg.DataGridView = dgvDuplicates;
            Dvgvg.Options = (Subro.Controls.GroupingOptions)resources.GetObject("Dvgvg.Options");
            // 
            // butGroup
            // 
            butGroup.Location = new Point(258, 12);
            butGroup.Name = "butGroup";
            butGroup.Size = new Size(114, 45);
            butGroup.TabIndex = 6;
            butGroup.Text = "Group";
            butGroup.UseVisualStyleBackColor = true;
            butGroup.Click += butGroup_Click;
            // 
            // DeDupeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 677);
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
        private Subro.Controls.DataGridViewGrouper Dvgvg;
        private Button butGroup;
    }
}