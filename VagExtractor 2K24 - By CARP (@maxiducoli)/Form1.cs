
namespace VagExtractor
{
    public partial class frmVagExtractor : Form
    {
        public frmVagExtractor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilesVags utilesVags = new UtilesVags();
            DialogResult dr;
            //Utiles utiles = new Utiles();
            byte[] tempRA;
            using (OpenFileDialog op = new OpenFileDialog())
            {
             op.Filter = "BIN FILES | *.bin";

                if (op.ShowDialog() == DialogResult.OK)
                {
                    rbVAG.Enabled = true;
                    rbWAV.Enabled = true;
                    tempRA = utilesVags.ExtraerArchivo(op.FileName, lstFiles.Items[lstFiles.SelectedIndex].ToString());
                    lblIsoPath.Text = op.FileName;
                    using (FileStream fs = new FileStream(Path.GetTempPath() + lstFiles.Items[lstFiles.SelectedIndex], FileMode.Create, FileAccess.Write))
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        fs.Write(tempRA, 0, tempRA.Length);
                    }
                }
            }


            //UtilesVags utilesVags = new UtilesVags();
            //string RA = "e:\\TEMP\\WE2002\\ISO FILES\\SD\\W2002J10.RA";
            //string archivo = "VAGp";
            //utilesVags.ExtraerArchivosVAG(RA, archivo, "E:\\TEMP\\VAGs\\");
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIsoPath.Text))
            { 
            btnIso.Enabled = true;
            rbWAV.Enabled = false;
            rbVAG.Enabled = false;
            btnFolder.Enabled = false;
            }
        }

        private void rbVAG_CheckedChanged(object sender, EventArgs e)
        {
            btnFolder.Enabled = true;

        }

        private void rbWAV_CheckedChanged(object sender, EventArgs e)
        {
            btnFolder.Enabled = true;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            UtilesVags utilesVags = new UtilesVags();
            DialogResult dt;
            string pathTemporal = string.Empty;
            string programa = Application.StartupPath + "Tools\\vag2wav.exe";
            byte[] tempRA;
            LBLMensaje.Visible = false;
            //

            if (rbVAG.Checked)
            {
                progressBar1.Value = 20 ;
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    dt = folderBrowserDialog.ShowDialog();
                    if (dt == DialogResult.OK)
                    {
                        pathTemporal = Path.GetTempPath() + Path.GetFileNameWithoutExtension(lstFiles.Items[lstFiles.SelectedIndex].ToString());
                        if (!Directory.Exists(pathTemporal))
                            Directory.CreateDirectory(pathTemporal);
                        tempRA = utilesVags.ExtraerArchivo(lblIsoPath.Text, lstFiles.Items[lstFiles.SelectedIndex].ToString());

                        using (FileStream fs = new FileStream(Path.GetTempPath() + lstFiles.Items[lstFiles.SelectedIndex].ToString(), FileMode.Create, FileAccess.Write))
                        {
                            fs.Seek(0, SeekOrigin.Begin);
                            fs.Write(tempRA, 0, tempRA.Length);
                        }
                        progressBar1.Value = 50;
                        // Extraemos los VAGs a un temporal
                        if (utilesVags.ExtraerArchivosVAG(Path.GetTempPath() + lstFiles.Items[lstFiles.SelectedIndex], "VAGp", folderBrowserDialog.SelectedPath))
                            MessageBox.Show("All done!");
                        progressBar1.Value = 100;
                    }
                }
                progressBar1.Value = 0;

            }

            if (rbWAV.Checked)
            {
                progressBar1.Value = 0;
                LBLMensaje.Visible = true;
                LBLMensaje.Text = "CREANDO WAVS, AGUARDE!";
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    dt = folderBrowserDialog.ShowDialog();
                    if (dt == DialogResult.OK)
                    {
                        pathTemporal = Path.GetTempPath() + Path.GetFileNameWithoutExtension(lstFiles.Items[lstFiles.SelectedIndex].ToString());
                        if (!Directory.Exists(pathTemporal))
                            Directory.CreateDirectory(pathTemporal);
                       
                        if (utilesVags.Wav2Vag(lblIsoPath.Text, lstFiles.Items[lstFiles.SelectedIndex].ToString(), programa, pathTemporal, folderBrowserDialog.SelectedPath))
                        {
                            MessageBox.Show("All done!");
                        }
                    }
                }
            }
            LBLMensaje.Text = string.Empty;
            LBLMensaje.Visible = false;

        }
    }
}
