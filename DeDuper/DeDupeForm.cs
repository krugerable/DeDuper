using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeDuper
{
    public partial class DeDupeForm : Form
    {
        public DeDupeForm()
        {
            InitializeComponent();
        }

        private string strFolderName = "";

        private void ButChooseDirectory_Click(object sender, EventArgs e)
        {
            if (fbdFolder.ShowDialog() == DialogResult.OK)
            {
                strFolderName = fbdFolder.SelectedPath;
            }
        }

        private async void ButScan_Click(object sender, EventArgs e)
        {
            ImageDirectoryScanner scanner = new(tbarThreshold.Value);
            var progress = new Progress<int>(percent =>
            {
                pBarScan.Value = percent;
            });

            if (strFolderName == "")
            {
                MessageBox.Show("Please select a folder to scan.");
                return;
            }
            else
            {
                await Task.Run(() => scanner.ScanForDuplicates(strFolderName, progress));
                dgvDuplicates.DataSource = scanner.DuplicateImages;
            }
        }

        private async void tbarThreshold_MouseUp(object sender, MouseEventArgs e)
        {
            ImageDirectoryScanner scanner = new(tbarThreshold.Value);
            var progress = new Progress<int>(percent =>
            {
                pBarScan.Value = percent;
            });

            if (strFolderName == "")
            {
                MessageBox.Show("Please select a folder to scan.");
                return;
            }
            else
            {
                await Task.Run(() => scanner.ScanForDuplicates(strFolderName, progress));
                dgvDuplicates.DataSource = scanner.DuplicateImages;
            }
        }

        private async void DeDupeForm_Load(object sender, EventArgs e)
        {
            ImageDirectoryScanner scanner = new(tbarThreshold.Value);
            var progress = new Progress<int>(percent =>
            {
                pBarScan.Value = percent;
            });

            if (strFolderName == "")
            {
                MessageBox.Show("Please select a folder to scan.");
                return;
            }
            else
            {
                await Task.Run(() => scanner.ScanForDuplicates(strFolderName, progress));
                dgvDuplicates.DataSource = scanner.DuplicateImages;
            }
        }
    }
}
