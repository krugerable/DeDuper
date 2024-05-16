using System.Security.Cryptography.Pkcs;

namespace App
{
    partial class Find
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
            barItem1 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            barItem2 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            barItem3 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            sfpbProgress = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            sftbSimilarity = new Syncfusion.Windows.Forms.Tools.TrackBarEx(0, 10);
            gbSettings = new GroupBox();
            rbPH = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            rbAH = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            rbDH = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            rbCH = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            sfbStart = new Syncfusion.WinForms.Controls.SfButton();
            sfbSelectFolder = new Syncfusion.WinForms.Controls.SfButton();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)sfpbProgress).BeginInit();
            gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rbPH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rbAH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rbDH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rbCH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // barItem1
            // 
            barItem1.BarName = "barItem1";
            barItem1.ShowToolTipInPopUp = false;
            barItem1.SizeToFit = true;
            // 
            // barItem2
            // 
            barItem2.BarName = "barItem2";
            barItem2.ShowToolTipInPopUp = false;
            barItem2.SizeToFit = true;
            // 
            // barItem3
            // 
            barItem3.BarName = "barItem3";
            barItem3.ShowToolTipInPopUp = false;
            barItem3.SizeToFit = true;
            // 
            // sfpbProgress
            // 
            sfpbProgress.BackMultipleColors = new Color[]
    {
    Color.Empty
    };
            sfpbProgress.BackSegments = false;
            sfpbProgress.CustomText = null;
            sfpbProgress.CustomWaitingRender = false;
            sfpbProgress.ForegroundImage = null;
            sfpbProgress.Location = new Point(12, 279);
            sfpbProgress.MultipleColors = new Color[]
    {
    Color.Empty
    };
            sfpbProgress.Name = "sfpbProgress";
            sfpbProgress.SegmentWidth = 12;
            sfpbProgress.Size = new Size(776, 24);
            sfpbProgress.TabIndex = 3;
            sfpbProgress.Text = "progressBarAdv1";
            sfpbProgress.WaitingGradientWidth = 400;
            // 
            // sftbSimilarity
            // 
            sftbSimilarity.BackColor = Color.White;
            sftbSimilarity.BeforeTouchSize = new Size(250, 20);
            sftbSimilarity.Location = new Point(6, 22);
            sftbSimilarity.Name = "sftbSimilarity";
            sftbSimilarity.Size = new Size(250, 20);
            sftbSimilarity.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            sftbSimilarity.TabIndex = 4;
            sftbSimilarity.Text = "trackBarEx1";
            sftbSimilarity.ThemeName = "Metro";
            sftbSimilarity.TimerInterval = 100;
            sftbSimilarity.Value = 5;
            // 
            // gbSettings
            // 
            gbSettings.Controls.Add(groupBox2);
            gbSettings.Controls.Add(groupBox1);
            gbSettings.Controls.Add(sfbSelectFolder);
            gbSettings.Controls.Add(sfbStart);
            gbSettings.Location = new Point(12, 12);
            gbSettings.Name = "gbSettings";
            gbSettings.Size = new Size(776, 261);
            gbSettings.TabIndex = 5;
            gbSettings.TabStop = false;
            gbSettings.Text = "Settings";
            // 
            // rbPH
            // 
            rbPH.AccessibilityEnabled = true;
            rbPH.Checked = true;
            rbPH.Location = new Point(19, 26);
            rbPH.MetroColor = Color.FromArgb(88, 89, 91);
            rbPH.Name = "rbPH";
            rbPH.Size = new Size(150, 21);
            rbPH.TabIndex = 5;
            rbPH.Text = "Perceptual Hash";
            // 
            // rbAH
            // 
            rbAH.AccessibilityEnabled = true;
            rbAH.Location = new Point(19, 53);
            rbAH.MetroColor = Color.FromArgb(88, 89, 91);
            rbAH.Name = "rbAH";
            rbAH.Size = new Size(150, 21);
            rbAH.TabIndex = 6;
            rbAH.TabStop = false;
            rbAH.Text = "Average Hash";
            // 
            // rbDH
            // 
            rbDH.AccessibilityEnabled = true;
            rbDH.Location = new Point(19, 80);
            rbDH.MetroColor = Color.FromArgb(88, 89, 91);
            rbDH.Name = "rbDH";
            rbDH.Size = new Size(150, 21);
            rbDH.TabIndex = 7;
            rbDH.TabStop = false;
            rbDH.Text = "Difference Hash";
            // 
            // rbCH
            // 
            rbCH.AccessibilityEnabled = true;
            rbCH.Location = new Point(19, 107);
            rbCH.MetroColor = Color.FromArgb(88, 89, 91);
            rbCH.Name = "rbCH";
            rbCH.Size = new Size(150, 21);
            rbCH.TabIndex = 8;
            rbCH.TabStop = false;
            rbCH.Text = "Color Histogram";
            // 
            // sfbStart
            // 
            sfbStart.Font = new Font("Segoe UI Semibold", 9F);
            sfbStart.Location = new Point(421, 22);
            sfbStart.Name = "sfbStart";
            sfbStart.Size = new Size(130, 97);
            sfbStart.TabIndex = 9;
            sfbStart.Text = "Start";
            sfbStart.UseVisualStyleBackColor = true;
            sfbStart.Click += sfbStart_Click;
            // 
            // sfbSelectFolder
            // 
            sfbSelectFolder.Font = new Font("Segoe UI Semibold", 9F);
            sfbSelectFolder.Location = new Point(285, 22);
            sfbSelectFolder.Name = "sfbSelectFolder";
            sfbSelectFolder.Size = new Size(130, 97);
            sfbSelectFolder.TabIndex = 10;
            sfbSelectFolder.Text = "Select Folder";
            sfbSelectFolder.UseVisualStyleBackColor = true;
            sfbSelectFolder.Click += sfbSelectFolder_Click;
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Location = new Point(12, 309);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(776, 453);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 6;
            sfDataGrid1.Text = "sfDataGrid1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbPH);
            groupBox1.Controls.Add(rbAH);
            groupBox1.Controls.Add(rbDH);
            groupBox1.Controls.Add(rbCH);
            groupBox1.Location = new Point(6, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 144);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Method";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(sftbSimilarity);
            groupBox2.Location = new Point(6, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(273, 78);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Similarity: default";
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 774);
            Controls.Add(sfDataGrid1);
            Controls.Add(gbSettings);
            Controls.Add(sfpbProgress);
            Name = "Find";
            Text = "Find";
            ((System.ComponentModel.ISupportInitialize)sfpbProgress).EndInit();
            gbSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rbPH).EndInit();
            ((System.ComponentModel.ISupportInitialize)rbAH).EndInit();
            ((System.ComponentModel.ISupportInitialize)rbDH).EndInit();
            ((System.ComponentModel.ISupportInitialize)rbCH).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem2;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem3;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv sfpbProgress;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx sftbSimilarity;
        private GroupBox gbSettings;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbDH;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbAH;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbPH;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbCH;
        private Syncfusion.WinForms.Controls.SfButton sfbSelectFolder;
        private Syncfusion.WinForms.Controls.SfButton sfbStart;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}