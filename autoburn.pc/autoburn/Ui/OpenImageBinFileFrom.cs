using Autoburn.Manager;
using Autoburn.util;
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
    public partial class OpenImageBinFileFrom : Form
    {
        public OpenImageBinFileFrom()
        {
            InitializeComponent();
          
        }
        public const string TAG = "OpenImageBinFile";
        #region Events
        public event EventHandler StateChanged;
        #endregion
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

                ImgBinFileInfo.ImageBinFileFullPath = _openFilePath;
                FileInfo fileinfo = new FileInfo(_openFilePath);
                ImgBinFileInfo.ImageBinFileLen = fileinfo.Length;
                ImgBinFileInfo.ImageBinFileName = fileinfo.Name;

                InitCalFileMd5work();
                // 
                CalFileMD5work.RunWorkerAsync();
            }
        }

        private void InitCalFileMd5work()
        {
            if (CalFileMD5work != null && CalFileMD5work.WorkerSupportsCancellation)
            {
                CalFileMD5work?.CancelAsync();
            }
            // CalFileMD5work
            // 
            CalFileMD5work = new BackgroundWorker();
            this.CalFileMD5work.WorkerReportsProgress = true;
            this.CalFileMD5work.WorkerSupportsCancellation = true;
            this.CalFileMD5work.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CalFileMD5work_DoWork);
            this.CalFileMD5work.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CalFileMD5work_ProgressChanged);
            this.CalFileMD5work.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CalFileMD5work_RunWorkerCompleted);
        }
        private System.ComponentModel.BackgroundWorker CalFileMD5work;

        private string _openFilePath = "";
        private string _md5sum = string.Empty;

        private ImgBinFileInfo ImgBinFileInfo = new ImgBinFileInfo();
        private void CalFileMD5work_DoWork(object sender, DoWorkEventArgs e)
        {
            CalFileMD5work?.ReportProgress(1); //start to cal md5sum 
            _md5sum = DoCalFileMd5(_openFilePath); // this function will last some times.
        }

        private void CalFileMD5work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    this.Cursor = Cursors.WaitCursor;
                   // this. = false;
                    break;
                default:
                    break;
            }
        }

        private void CalFileMD5work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;
            filemd5sumlab.Text = _md5sum;
            ImgBinFileInfo.ImageBinFileMD5Sum = _md5sum;
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
            if (!string.IsNullOrEmpty(ImgBinFileInfo.ImageBinFileMD5Sum))
            {
                StateChanged?.Invoke(this, ImgBinFileInfo); // 
                SystemLog.I(TAG, ImgBinFileInfo);
            }

            if (CalFileMD5work != null && CalFileMD5work.WorkerSupportsCancellation)
            {
                CalFileMD5work?.CancelAsync();
            }
            Dispose();
        }

        private void chacelbutton_Click(object sender, EventArgs e)
        {
            // StateChanged?.Invoke(this, ImgBinFileInfo); // 
            if (CalFileMD5work != null && CalFileMD5work.WorkerSupportsCancellation)
            {
                CalFileMD5work?.CancelAsync();
            }
            Dispose();
        }

    }
}
