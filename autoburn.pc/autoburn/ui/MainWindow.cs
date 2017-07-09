using Autoburn.Manager;
using Autoburn.Net;
using Autoburn.Ui;
using Autoburn.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Autoburn.Net.DeviceNetManager;

namespace Autoburn.Ui
{
    public partial class MainWindow : Form
    {
        private string TAG = "MainWindow";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }
        public MainWindow()
        {
            InitializeComponent();

            _HasWindowShow = true;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private bool _HasWindowShow = false;
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _HasWindowShow = false;
            D("MainWindow_FormClosing");
        }


        #region 选择芯片
        private ChooseChipFrom _ChooseChipFrom = null;
        private ChipInfo CurrentChooseChip = null;
        private void ChooseChipMenuItem_Click(object sender, EventArgs e1)
        {
            if (_ChooseChipFrom == null)
            {
                _ChooseChipFrom = new ChooseChipFrom();
                _ChooseChipFrom.StateChanged += delegate(object o, EventArgs e)
                {
                    ChooseChipFrom.ChooseChipFromEventArgs args = e as ChooseChipFrom.ChooseChipFromEventArgs;
                    CurrentChooseChip = args.ChipInfo;
                    AccordionPanel.ChipinfoVendor = CurrentChooseChip.vendor;
                    AccordionPanel.ChipinforName = CurrentChooseChip.name;
                    AccordionPanel.ChipinforPackage = CurrentChooseChip.package;
                    AccordionPanel.ChipinforCapcity = "-";
                    AccordionPanel.ChipinforBurner = CurrentChooseChip.burner;
                };
            }
            _ChooseChipFrom.ShowDialog();
        }
        #endregion

        private void NewProjectStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stream myStream;
            //SaveFileDialog savefileDialog = new SaveFileDialog();

            //savefileDialog.Title = "新建工程";
            //savefileDialog.Filter = "工程文件|*.ccp";
            //savefileDialog.RestoreDirectory = true;

            //if (savefileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = savefileDialog.OpenFile()) != null)
            //    {
            //        filename = savefileDialog.FileName;
            //        // Code to write the stream goes here.
            //        myStream.Write(Encoding.ASCII.GetBytes(savefileDialog.FileName), 0, savefileDialog.FileName.Length);
            //        myStream.Close();
            //    }
            //}
            SaveProject sp = new SaveProject();
            sp.ShowDialog();

        }

        public string filename = "";
        private void OpenProjectStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

          //  openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Title = "保存工程";
            openFileDialog1.Filter = "工程文件|*.ccp";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ProjecthistorytoolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void openFileDialog_Click(object sender, EventArgs e)
        {
            OpenImageBinFile openimagebinfile = new OpenImageBinFile();
            openimagebinfile.ShowDialog();
        }




        #region NOT changed 
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox _aboutbox = new AboutBox();
            _aboutbox.ShowDialog();
        }

        #endregion

        #region NOT USE
        private void UpdateUi(CONNECT_STATUS c, object[] o)
        {
            D("UpdateUi: " + c);
            if (!IsHandleCreated || !_HasWindowShow)
            {
                return;
            }
            switch (c)
            {
                case CONNECT_STATUS.DISCOVERY_INIT_OK:
                    Invoke((MethodInvoker)delegate () {
                        statusdiscovery.Text = "discovery 初始化成功";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_INIT_ERROR:
                    Invoke((MethodInvoker)delegate () {
                        statusdiscovery.Text = "discovery 初始化失败";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_GET_PCB:
                    IPEndPoint ip = (IPEndPoint)o[0];
                    Invoke((MethodInvoker)delegate () {
                        statusdiscovery.Text = "连接: " + ip.Address;
                    });
                    break;
                case CONNECT_STATUS.TCP_CONNECT_OK:
                    Invoke((MethodInvoker)delegate () {
                        statusTcpStatus.Text = "tcp 已经初始化成功";
                    });
                    break;
                case CONNECT_STATUS.TCP_CONNECT_ERROR:
                case CONNECT_STATUS.TCP_SEND_MSG_ERROR:
                case CONNECT_STATUS.TCP_RECV_MSG_ERROR:
                    Invoke((MethodInvoker)delegate () {
                        statusTcpStatus.Text = "tcp 连接断开";
                    });
                    break;
                case CONNECT_STATUS.TCP_RECEIVE_MSG:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
