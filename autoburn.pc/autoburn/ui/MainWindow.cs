using Autoburn.Manager;
using Autoburn.Net;
using Autoburn.Ui;
using Autoburn.util;
using SharpAdbClient;
using System;
using System.Collections;
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
        }

        private void BindAdbStatus()
        {
            // init first.
            var adbdevicedata = DeviceManager.Instance.WrapAdbManager.GetCurrentAdbDeviceData();
            if (adbdevicedata.State.Equals(DeviceState.Online))
            {
                SystemLog.I(TAG, "初始化找到ADB设备 :" + adbdevicedata.ToString());
                AdbStatusToollable.Text = "设备已连接";
                Task.Run(new Action(startNetty));
            }
            else if (adbdevicedata.State.Equals(DeviceState.Offline))
            {
                SystemLog.I(TAG, "初始化末找到ADB设备 :" + adbdevicedata.ToString());
                AdbStatusToollable.Text = "设备已断开";
                NettyJsonCmdManager?.Stop();
            }
            // add monitoer
            DeviceManager.Instance.WrapAdbManager.DeviceStatusChanged += delegate (object sender, DeviceDataEventArgs data)
           {
               var devicedata = data.Device;
               if (devicedata.State.Equals(DeviceState.Online))
               {
                   SystemLog.I(TAG, "设备连接 :" + devicedata.ToString());
                   AdbStatusToollable.Text = "设备已连接";
                   Task.Run(new Action(startNetty));
               }
               else if (devicedata.State.Equals(DeviceState.Offline))
               {
                   SystemLog.I(TAG, "设备已断开 :" + devicedata.ToString());
                   AdbStatusToollable.Text = "设备已断开";
                   NettyJsonCmdManager?.Stop();
               }
           };
        }

        private void startNetty()
        {
            NettyJsonCmdManager?.Stop();
            NettyJsonCmdManager = new NettyJsonCmdManager();
            NettyJsonCmdManager?.Start();

            DeviceManager.Instance.NettyJsonCmdManager = NettyJsonCmdManager;
        }

        NettyJsonCmdManager NettyJsonCmdManager = null;

        private void Form1_Load(object sender, EventArgs e)
        {//bind some thing.adb连接状态的监控.
            BindAdbStatus();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceManager.Instance.Stop();
            NettyJsonCmdManager?.Stop();
            D("MainWindow_FormClosing");
          
        }

        #region 选择芯片
        private ChooseChipFrom _ChooseChipFrom = null;
        private ChipInfo CurrentChooseChip = null; //当前选择的芯片.
        private void ChooseChipMenuItem_Click(object sender, EventArgs e1)
        {
            if (_ChooseChipFrom == null)
            {
                _ChooseChipFrom = new ChooseChipFrom();
                _ChooseChipFrom.StateChanged += delegate(object o, EventArgs e)
                {
                    ChooseChipFrom.ChooseChipFromEventArgs args = e as ChooseChipFrom.ChooseChipFromEventArgs;
                    CurrentChooseChip = args.ChipInfo;
                    AccordionPanel.CurrentChipInfo = CurrentChooseChip;
                };
            }
            _ChooseChipFrom.ShowDialog();
        }
        #endregion

        private Hashtable CurrentProjectInfoHashTable = new Hashtable();
        private void NewProjectStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectFrom sp = new SaveProjectFrom();
            sp.StateChanged += delegate (object o, EventArgs e1)
            {
                SaveProjectFrom.ProjectInfoHashtableEventArgs args = e1 as SaveProjectFrom.ProjectInfoHashtableEventArgs;
                CurrentProjectInfoHashTable = args.ProjectInfoHashtable;
                AccordionPanel.CurrentProjectInfoHashTable = CurrentProjectInfoHashTable;
            };
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

        private ImgBinFileInfo CurrentimgBintFileInfo = null; //当前的镜像文件
        private void openFileDialog_Click(object sender, EventArgs e)
        {
            OpenImageBinFileFrom openimagebinfile = new OpenImageBinFileFrom();
            openimagebinfile.StateChanged += delegate(object o, EventArgs e1)
            {
                CurrentimgBintFileInfo = e1 as ImgBinFileInfo;
                AccordionPanel.CurrentimgBintFileInfo = CurrentimgBintFileInfo;
            };

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
            if (!IsHandleCreated )
            {
                return;
            }
            switch (c)
            {
                case CONNECT_STATUS.DISCOVERY_INIT_OK:
                    Invoke((MethodInvoker)delegate () {
                        AdbStatusToollable.Text = "discovery 初始化成功";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_INIT_ERROR:
                    Invoke((MethodInvoker)delegate () {
                        AdbStatusToollable.Text = "discovery 初始化失败";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_GET_PCB:
                    IPEndPoint ip = (IPEndPoint)o[0];
                    Invoke((MethodInvoker)delegate () {
                        AdbStatusToollable.Text = "连接: " + ip.Address;
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
