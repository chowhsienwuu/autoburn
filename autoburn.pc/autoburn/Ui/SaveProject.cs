using Autoburn.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoburn.Ui
{
    public partial class SaveProject : Form
    {
        public SaveProject()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private void InitializeComponent2()
        {
            this.TrayType.SelectedIndex = 0;
        
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            var trayType = TrayType.SelectedItem;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void choosepath_Click(object sender, EventArgs e)
        {
            //魏保存的文件名,再建立同名的文件夹,在此文件夹下保存工程文件??
            SaveFileDialog savefileDialog = new SaveFileDialog();

            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                //savefileDialog.FileName
                saveprojecttext.Text = savefileDialog.FileName;
                saveprojectdir = savefileDialog.FileName;
                if (Directory.CreateDirectory(saveprojectdir).Exists)
                {

                }
            }

            //直接选择保存的文件夹.
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    saveprojectdir = fbd.SelectedPath;
            //    DirectoryInfo folder = new DirectoryInfo(fbd.SelectedPath);
            //    var dirinfo = folder.EnumerateFiles().ToArray();
            //    if (dirinfo.Length > 0)
            //    {//file not empty .
            //         DialogResult result =   MessageBox.Show(null, "所选文件夹非空,是否仍要保存,建议选择空文件夹",
            //            "选择文件夹", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }                
            //}
            ProjectManager ProjectManager = DeviceManager.Instance.ProjectManager; ;
            if (saveprojectdir.Length > 2)
            {
                ProjectManager.ReSet();
                ProjectManager.InitDir(saveprojectdir);
            }

            var keyvalue = new Hashtable();

            var lasindex = saveprojectdir.LastIndexOf('\\');
            var projectname = saveprojectdir.Substring(lasindex + 1);
            keyvalue.Add(ProjectInfo.TYPE_KEY_PROJECT_NAME, projectname); //时间.

            var now = DateTime.Now.ToLocalTime().ToString();
            keyvalue.Add(ProjectInfo.TYPE_KEY_CREATETIME, now); //时间.
            keyvalue.Add(ProjectInfo.TYPE_KEY_TRAY_TYPE, TrayType.SelectedIndex.ToString());// 料盘类型

            ProjectManager.ExeSetKeyVal(keyvalue);
        }


        private string saveprojectdir = "";
    }
}
