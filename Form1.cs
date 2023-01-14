namespace Daftarche
{
    public partial class MainForm1 : System.Windows.Forms.Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }
        string path = string.Empty;
        bool filestatus = false;
        private void AboutDaftarche_Click(object sender, EventArgs e)
        {
           MessageBox.Show(this, "Name: About Daftarche (Text Editor)\nVersion: 1.0\nDeveloper: pouriiiat", "About Daftarche (Text Editor)",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(path = SaveFileDialog.FileName, TextBox.Text);
                if (filestatus == true)
                {
                    filestatus = false;
                    this.Text = "Daftarche (Text Editor)";
                }
            }
            else
            {
                MessageBox.Show(this, "Error Save File " + SaveFileDialog.FileName, "Error Daftarche", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                File.WriteAllText(path, TextBox.Text);
                if (filestatus == true)
                {
                    filestatus = false;
                    this.Text = "Daftarche (Text Editor)";
                }
            }
            else
            {
                SaveAs_Click(sender,e);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (filestatus == false)
            {
                this.Text = "*" + this.Text;
                filestatus = true;
            }
        }
    }
}