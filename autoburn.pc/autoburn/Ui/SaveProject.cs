using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //Stream myStream;
            SaveFileDialog savefileDialog = new SaveFileDialog();

            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                //savefileDialog.FileName
                saveprojecttext.Text = savefileDialog.FileName;
            }

        }
    }
}
