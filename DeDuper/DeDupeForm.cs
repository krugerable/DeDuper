using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeDuper
{
    public partial class DeDupeForm : Form
    {
        public DeDupeForm()
        {
            InitializeComponent();
        }

        private string strFolderName = "";

        private void butChooseDirectory_Click(object sender, EventArgs e)
        {
            if (fbdFolder.ShowDialog() == DialogResult.OK)
            {
                strFolderName = fbdFolder.SelectedPath;
            }
        }

        private void butScan_Click(object sender, EventArgs e)
        {
            // Inside your Form Load event or appropriate method
            ImageDirectoryScanner scanner = new ImageDirectoryScanner(tbarThreshold.Value);  // Adjust the threshold as needed
            scanner.ScanForDuplicates(strFolderName);
            dgvDuplicates.DataSource = scanner.DuplicateImages;
            dgvDuplicates.Columns["GroupId"].HeaderText = "Group ID";
            dgvDuplicates.Columns["ImagePath"].HeaderText = "Image Path";
            dgvDuplicates.Columns["SimilarityScore"].HeaderText = "Similarity Score";

        }
    }
}
