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
            components = new System.ComponentModel.Container();
            gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            barItem1 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            barItem2 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            barItem3 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            trackBar1 = new TrackBar();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)gridGroupingControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // gridGroupingControl1
            // 
            gridGroupingControl1.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            gridGroupingControl1.BackColor = SystemColors.Window;
            gridGroupingControl1.Location = new Point(12, 63);
            gridGroupingControl1.Name = "gridGroupingControl1";
            gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            gridGroupingControl1.Size = new Size(776, 375);
            gridGroupingControl1.TabIndex = 1;
            gridGroupingControl1.Text = "gridGroupingControl1";
            gridGroupingControl1.UseRightToLeftCompatibleTextBox = true;
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
            // trackBar1
            // 
            trackBar1.Location = new Point(418, 12);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(370, 45);
            trackBar1.TabIndex = 2;
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar1);
            Controls.Add(gridGroupingControl1);
            Name = "Find";
            Text = "Find";
            ((System.ComponentModel.ISupportInitialize)gridGroupingControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem2;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem3;
        private TrackBar trackBar1;
        private BindingSource bindingSource1;

    }
}