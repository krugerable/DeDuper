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
            gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)gridGroupingControl1).BeginInit();
            SuspendLayout();
            // 
            // gridGroupingControl1
            // 
            gridGroupingControl1.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            gridGroupingControl1.BackColor = SystemColors.Window;
            gridGroupingControl1.Location = new Point(372, 146);
            gridGroupingControl1.Name = "gridGroupingControl1";
            gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            gridGroupingControl1.Size = new Size(130, 80);
            gridGroupingControl1.TabIndex = 1;
            gridGroupingControl1.Text = "gridGroupingControl1";
            gridGroupingControl1.UseRightToLeftCompatibleTextBox = true;
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridGroupingControl1);
            Name = "Find";
            Text = "Find";
            ((System.ComponentModel.ISupportInitialize)gridGroupingControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
    }
}