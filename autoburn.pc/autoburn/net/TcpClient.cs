using Autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Autoburn.Net.DeviceNetManager;

namespace Autoburn.Net
{
    public class TcpCmdClient
    {
        private string TAG = "TcpCmdClient";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }

        private IPEndPoint _PcbTcpServerEndPoint = null;
        public TcpCmdClient(IPEndPoint ip)
        {
            _PcbTcpServerEndPoint = ip;
            _TcpreceiveThread = new Thread(new ThreadStart(DoInitAndReceiv));
            _TcpreceiveThread.Name = "TCPclient " + DateTime.Now;
            _TcpreceiveThread.Start();

        }
        Thread _TcpreceiveThread = null;
        private AutoResetEvent _SendThreadAutoResetEvent = new AutoResetEvent(true);

        internal void Stop()
        {
            ReleaseTcp(true);
            _SendThreadAutoResetEvent.Close();
            _SendThreadAutoResetEvent.Dispose();
            _TcpCmdClient?.Close();
            _TcpNetworkStream?.Close();
            try
            {
                _ThreadTcpSend?.Abort();
                _TcpreceiveThread?.Abort();
            }
            catch { }
        }

        private bool _KeepRunning = true;
        private bool _HasInit = false;
        private bool _HasError = true;

        private bool mHelloMsg = true;
        /* 这是一个单独线程函数*/
        public void DoInitAndReceiv()
        {
            while (_KeepRunning)
            {
                if (!_HasInit || _HasError && _KeepRunning)
                {
                    DoInit();
                }
                // receive .
                if (_HasInit && !_HasError && _KeepRunning)
                {
                    string receivemsg = "";
                    try
                    {
                        ReceiveLen = _TcpNetworkStream.Read(mReceive, 0, mReceive.Length);
                        receivemsg = Encoding.UTF8.GetString(mReceive, 0, ReceiveLen);
                        D("receive msg len " + ReceiveLen);
                        if (ReceiveLen < 1)
                        { //we get a eeor.
                            D("receive msg len " + ReceiveLen + " may be error");
                            _HasError = true;
                        }
                        else
                        {
                            TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_RECEIVE_MSG, receivemsg);
                        }
                    }
                    catch
                    {
                        D("tcpcmd Do receive error");
                        _HasError = true;
                        TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_RECV_MSG_ERROR, "RECV MSG ERROR");
                    }
                }

                if (_HasError && _KeepRunning)
                {
                    // 如果有错,先回收res,等3S,再试, 只考虑一台设备的情况
                    TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_CONNECT_ERROR, "TCP_CONNECT_ERROR");
                    ReleaseTcp(false);
                    D("TcpClient get a error wait 3s");
                    Thread.Sleep(3000);
                }
            }
        }

        // b 选择是否退出线程, 不退出以便可以重试
        private void ReleaseTcp(bool b)
        {
            if (b)
            {
                _KeepRunning = false;
                _SendThreadAutoResetEvent.Set();
            }
        }

        private byte[] mReceive = new byte[1024];
        private int ReceiveLen = 0;

        #region no use begain 
        private void _f()
        {
            if (mHelloMsg)
            {
                string message = "{\"msgtype\": \"hello\"}";
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                _TcpNetworkStream.Write(data, 0, data.Length);

                String responseData = String.Empty;
                data = new byte[100];
                int len = _TcpNetworkStream.Read(data, 0, data.Length);
                D(".receive : " + System.Text.Encoding.UTF8.GetString(data, 0, len));
                mHelloMsg = false;
                TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_CONNECT_OK, "hello");
            }
        }
        #endregion no use end

        /* 这是一个单独线程函数*/
        private void DoSendMsg()
        {
            while (!_HasError && _KeepRunning)
            {
                 D("do sendMsg before");
                _SendThreadAutoResetEvent.WaitOne();
                lock (_SendMsgLock)
                {
                    D("do sendMsg after");
                    if (_TcpNetworkStream == null || mSendByte == null || _HasError || !_HasInit)
                    {
                        continue;
                    }
                    try
                    {
                        _TcpNetworkStream.Write(mSendByte, 0, mSendByte.Length);
                        mSendByte = null;
                    }
                    catch (Exception e)
                    {
                        D("tcpcmd Do SendMsg error " + e.ToString());
                        _HasError = true;
                        TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_SEND_MSG_ERROR, "SEND MSG ERROR");
                    }
                }
            }
            D("tcpcmd Do SendMsg error , end of send thread");
        }

        byte[] mSendByte = null;
        private object _SendMsgLock = new object(); //to protect sendbuffer.
        public void SendMsg(string msg)
        {
            D("SendMsg " + msg);
            if (msg == null || mSendByte != null || _HasError)
            {
                return;
            }
            lock(_SendMsgLock)
            {
                mSendByte = Encoding.UTF8.GetBytes(msg);
                _SendThreadAutoResetEvent.Set();
            }
        }

        private TcpClient _TcpCmdClient = null;
        private NetworkStream _TcpNetworkStream = null;
        private Thread _ThreadTcpSend = null;

        private bool DoInit()
        {
            var b = false;
            try
            {
                _TcpCmdClient?.Close();
                _TcpCmdClient = new TcpClient();
                D("create TcpClient instance");

                D("TCP begain connect:" + DateTime.Now);
                _TcpCmdClient.Connect(_PcbTcpServerEndPoint);
                D("Tcp end connect:" + DateTime.Now);
                _TcpCmdClient.NoDelay = true;
                _TcpNetworkStream = _TcpCmdClient.GetStream();
                // 当有多个网卡时,用于区别是哪个网卡起的作用.
                IPEndPoint iep = (IPEndPoint)_TcpCmdClient.Client.LocalEndPoint;
                ProgramInfo.PCIPaddr = iep.Address.ToString();
            }
            catch (Exception e)
            {
                D("tcp connect error " + e);
            }

            try
            {
                b = _TcpCmdClient.Connected;
            }
            catch
            {
                b = false;
            }
            D("TcpClinet : " + b);

            if (b)
            {
                TcpStatusChangeHandler?.Invoke(CONNECT_STATUS.TCP_CONNECT_OK, "TCP_CONNECT_OK");
                _HasInit = true;
                _HasError = false;

                _ThreadTcpSend = new Thread(new ThreadStart(DoSendMsg));
                _ThreadTcpSend.Name = "tcpsend " + DateTime.Now;
                _ThreadTcpSend.Start();
            }
            else
            {
                _HasInit = false;
                _HasError = true;
            }

            return b;
        }

        public delegate void TcpStatusChange(DeviceNetManager.CONNECT_STATUS c, object o);
        public TcpStatusChange TcpStatusChangeHandler;
    }
}

