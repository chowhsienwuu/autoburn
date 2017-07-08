using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoburn.Ui
{
    public partial class OpenImageBinFile : Form
    {
        public OpenImageBinFile()
        {
            InitializeComponent();
          
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "镜像文件 (*.img)|*.img|  二进制文件 (*.bin)|*.bin | 全部文件|*";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                _openFilePath = ofd.FileName;
                openfiletext.Text = _openFilePath;
                CalFileMD5work.RunWorkerAsync();
            }
        }

        private string _openFilePath = "";
        private string _md5sum = string.Empty;
        private void CalFileMD5work_DoWork(object sender, DoWorkEventArgs e)
        {
            CalFileMD5work.ReportProgress(1);
            _md5sum = DoCalFileMd5(_openFilePath);
        }

        private void CalFileMD5work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    this.Cursor = Cursors.WaitCursor;

                    break;
                default:
                    break;
            }
        }

        private void CalFileMD5work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            filemd5sumlab.Text = _md5sum;
        }

        private string DoCalFileMd5(string filename)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        var buffer = md5.ComputeHash(stream);
                        var sb = new StringBuilder();
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            sb.Append(buffer[i].ToString("x2"));
                        }
                        return sb.ToString();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {

        }

        private void chacelbutton_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
