using autoburn.net;
using autoburn.ui;
using autoburn.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static autoburn.net.DeviceNetManager;

namespace autoburn
{
    public partial class MainWindow : Form
    {
        private string TAG = "Form1";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }
        public MainWindow()
        {
            InitializeComponent();

            _DeviceNetManager.UpdateUiHandler += UpdateUi;
            _DeviceNetManager.Start(); //start discovery.

            _HasWindowShow = true;
        }

        private void UpdateUi(CONNECT_STATUS c, object[] o)
        {
            D("UpdateUi: " + c );
            if (!IsHandleCreated || !_HasWindowShow)
            {
                return;
            }
            switch (c)
            {
                case CONNECT_STATUS.DISCOVERY_INIT_OK:
                    Invoke((MethodInvoker)delegate () {
                        discovery.Text = "discovery 初始化成功";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_INIT_ERROR:
                    Invoke((MethodInvoker)delegate () {
                        discovery.Text = "discovery 初始化失败";
                    });
                    break;
                case CONNECT_STATUS.DISCOVERY_GET_PCB:
                    IPEndPoint ip = (IPEndPoint)o[0];
                    Invoke((MethodInvoker)delegate(){
                        discovery.Text = "板子网络连接: " + ip.Address;
                    });
                    break;
                case CONNECT_STATUS.TCP_CONNECT_OK:
                    Invoke((MethodInvoker)delegate () {
                        tcpstatus.Text = "tcp 已经初始化成功";
                    });
                    break;
                case CONNECT_STATUS.TCP_CONNECT_ERROR:
                case CONNECT_STATUS.TCP_SEND_MSG_ERROR:
                case CONNECT_STATUS.TCP_RECV_MSG_ERROR:
                    Invoke((MethodInvoker)delegate () {
                        tcpstatus.Text = "tcp 连接断开";
                    });
                    break;
                case CONNECT_STATUS.TCP_RECEIVE_MSG:
                    string msg = (string)o[0];
                    Invoke((MethodInvoker)delegate () {
                        if (receivemsgstring.TextLength > 2000)
                        {
                            receivemsgstring.Clear();
                        }
                        receivemsgstring.AppendText("\n-------------\n" + msg + "\n");
                    });
                    break;
                default:
                    break;
            }
        }

        private DeviceNetManager _DeviceNetManager = DeviceNetManager.instance;
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void sendtcpcmd_Click(object sender, EventArgs e)
        {
            if (sendmsgstring.TextLength < 1 )
            {
                return;
            }
            _DeviceNetManager.TcpSendMsg(sendmsgstring.Text);
            D("click send string");
        }

        private bool _HasWindowShow = false;
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _HasWindowShow = false;
            D("MainWindow_FormClosing");
            _DeviceNetManager.Stop();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
           AboutBox _aboutbox =  new AboutBox();
            _aboutbox.ShowDialog();
        
        }

        ChooseChipFrom _ChooseChipFrom = new ChooseChipFrom();
        private void ChooseChipMenuItem_Click(object sender, EventArgs e)
        {
            _ChooseChipFrom.ShowDialog();
        }
    }
}
