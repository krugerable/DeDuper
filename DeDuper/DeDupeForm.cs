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

        private async void CheckDuplication()
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

        private async void ButScan_Click(object sender, EventArgs e)
        {
            CheckDuplication();
        }

        private async void TbarThreshold_MouseUp(object sender, MouseEventArgs e)
        {
            CheckDuplication();
        }

        private async void DeDupeForm_Load(object sender, EventArgs e)
        {
            CheckDuplication();
        }

        private void dgvDuplicates_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PreviewSelectedImage.Image = Image.FromFile((string?)dgvDuplicates.SelectedRows[0].Cells[1].Value);
        }

        private void butGroup_Click(object sender, EventArgs e)
        {
            Dvgvg.SetGroupOn(dgvDuplicates.Columns[0]);
        }

        private void dgvDuplicates_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDuplicates.SelectedRows.Count > 0)
                PreviewSelectedImage.Image = Image.FromFile((string?)dgvDuplicates.SelectedRows[0].Cells[1].Value);
        }

        private void butMethodSelection_Click(object sender, EventArgs e)
        {

        }
    }
}
