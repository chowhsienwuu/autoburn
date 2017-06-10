using autoburn.util;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using static autoburn.net.DeviceNetManager;

namespace autoburn.net
{
    //监听UDP UDP_LISTEN_PORT = 18000 端口, 可以收到PCM板子发送的心跳包 即可发现板子.
    class BeatHeat
    {
        private string TAG = "BeatHeat";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }

        public BeatHeat(int port)
        {
            _UdpListenPort = port;

            D("BeatHead Udp port :" + _UdpListenPort);
        }

        private int _UdpListenPort;
        private bool _HasError = false;
        private bool _HasInit = false;

        private UdpClient _UdpClient = null;
        private IPEndPoint _RemoteIpEndPoint = null;

        private void doInitUdp()
        {
            try
            {
                _UdpClient = new UdpClient(_UdpListenPort);
                _RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                _HasInit = true;
                _HasError = false;
            }
            catch (Exception e)
            {
                _HasError = true;
                _UdpClient.Close();
                D("exceptio e " + e.ToString());
                BeatHeatStatusChangeHandler?.Invoke(CONNECT_STATUS.DISCOVERY_INIT_ERROR, new IPEndPoint(IPAddress.Any, 0));
            }
        }

        private byte[] _RecevBytes = new byte[1];
        private bool _KeepRunning = true;
        private int _InitOkIndex = 0;
        public void doWork()
        {
            while (_KeepRunning)
            {
                //  D("UDP receive loop"); 
                if (!_HasInit)
                {
                    doInitUdp();
                }
                if (!_HasError)
                {
                    try
                    {
                        if (_InitOkIndex++ == 0)
                        {
                            IPEndPoint tIPendPoint = new IPEndPoint(IPAddress.Any, 0);
                            BeatHeatStatusChangeHandler?.Invoke(CONNECT_STATUS.DISCOVERY_INIT_OK, tIPendPoint);
                        }
                        // Blocks until a message returns on this socket from a remote host.
                         // if (_UdpClient.Available > 0)
                      //  {
                        _RecevBytes = _UdpClient.Receive(ref _RemoteIpEndPoint);
                        // }
                    }
                    catch (Exception e)
                    {
                        D("receive exception : " + e.ToString());
                        _HasError = true;
                    }
                }
                //D("" + mRemoteIpEndPoint.Address.ToString()  + ":" + mRemoteIpEndPoint.Port.ToString());
                if ((!_HasInit || _HasError) && _KeepRunning)
                {
                    Thread.Sleep(3000);//wait a moment. 

                    try
                    {
                        _UdpClient?.Close();
                    }
                    catch { }

                    _HasInit = false;
                }

                if (!_HasError)
                {
                    ParseUdpPkg(_RecevBytes, _RemoteIpEndPoint);
                }
            }
        }

        public void Stop()
        {
            _KeepRunning = false;
            try
            {
                _UdpClient?.Close();
            }
            catch { }
        }

        //        {
        //    "msgtype": "broadcast", 
        //    "promt": "testpcb", 
        //    "index": 1, 
        //    "ip": "192.168.31.128", 
        //    "udpport": 28000, 
        //    "tcpport": 28001
        //}
        // {"msgtype":"Test", "gogo":"98"}
        private void ParseUdpPkg(byte[] msg, IPEndPoint iep)
        {
            if (msg == null || msg.Length < 2)
            {
                return;
            }
            string msgstring = Encoding.Default.GetString(msg);
            //       D("udp receiv: " + msgstring);
            //         D("udp endpoint " + iep.Address + " port:" + iep.Port);
            try
            {
                JObject obj = JObject.Parse(msgstring);
                string msgtype = obj["msgtype"].ToString();
                //D("the msgtype is " + msgtype);

                switch (msgtype)
                {
                    case "broadcast":
                        int port = ProgramInfo.PCB_TCP_SERVER_LISTEN_PORT;
                        string ipaddr = iep.Address.ToString();
                        IPEndPoint pcbtcp = new IPEndPoint(IPAddress.Parse(ipaddr), port);
                        if (_PcbTcpServerEndPoint == null || (pcbtcp.Address != _PcbTcpServerEndPoint.Address && pcbtcp.Port != _PcbTcpServerEndPoint.Port))
                        {
                            D("get broadcast : pcbTcpEndPoint is " + pcbtcp.Address + ":" + pcbtcp.Port);
                            _PcbTcpServerEndPoint = pcbtcp;
                            D("set mPcbTcp ");
                            ProgramInfo.PCBIPAddrEndPoint = _PcbTcpServerEndPoint;
                            BeatHeatStatusChangeHandler?.Invoke(CONNECT_STATUS.DISCOVERY_GET_PCB, _PcbTcpServerEndPoint);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (JsonException je)
            {
                D("jsonexception " + je.ToString());
            }
        }

        private IPEndPoint _PcbTcpServerEndPoint = null;

        public delegate void BeatHeatStatusChange(CONNECT_STATUS d, IPEndPoint i);
        public BeatHeatStatusChange BeatHeatStatusChangeHandler;
    }
}

