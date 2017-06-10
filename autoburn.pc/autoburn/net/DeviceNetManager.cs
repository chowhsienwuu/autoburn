using autoburn.ftp;
using autoburn.msghandler;
using autoburn.util;
using System.Net;
using System.Threading;

namespace autoburn.net
{
    public class DeviceNetManager
    {
        private string TAG = "DeviceNetManager";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }
        //thread safety instance .
        public static readonly DeviceNetManager instance = new DeviceNetManager();

        private DeviceNetManager() {
        }

        public void Stop()
        {
             _BeatHeat?.Stop();
            _TcpCmdClient?.Stop();
            FtpInstanceServer.instance.Stop();
            _RxMsgDispatch.Stop();
        }

        private BeatHeat _BeatHeat = null;
        private Thread _BeatHeatThread = null;
        private RxMsgDispatch _RxMsgDispatch;
        public void Start()
        {
            // return;
            _RxMsgDispatch = new RxMsgDispatch(this);

             _BeatHeat = new BeatHeat(ProgramInfo.PC_UDP_LISTEN_PORT);
            _BeatHeat.BeatHeatStatusChangeHandler += ProcessNetStatus;

            _BeatHeatThread = new Thread(new ThreadStart(_BeatHeat.doWork));
            _BeatHeatThread.Name = "BEATHEAT";
            _BeatHeatThread.Start();
        }

        private IPEndPoint _PcbTcpServerEndPoint = null;

        private void ProcessNetStatus(CONNECT_STATUS st, object o)
        {
            D("processDiscovery : st : " + st + "object : " + o + "ConnectStatusCallBackHandler:" + UpdateUiHandler);
            UpdateUiHandler?.Invoke(st, new object[] { o });
            switch (st)
            {
                case CONNECT_STATUS.DISCOVERY_INIT_OK:
                    break;
                case CONNECT_STATUS.DISCOVERY_GET_PCB:
                    _PcbTcpServerEndPoint = (IPEndPoint)o;
                    _TcpCmdClient = new TcpCmdClient(_PcbTcpServerEndPoint);

                    _TcpCmdClient.TcpStatusChangeHandler += ProcessNetStatus;
                    break;
                case CONNECT_STATUS.TCP_CONNECT_OK: //network is ok. so I open TcpServer.
                    if (ProgramInfo.PCIPaddr != null && !_hasFtprun)
                    {
                        FtpInstanceServer.instance.Start(ProgramInfo.FtpServerRootPath, ProgramInfo.PCIPaddr);
                        FtpInstanceServer.instance.FtpServerStatusChangeeHandler += ProcessNetStatus;
                        _hasFtprun = true;
                    }
                    break;
                case CONNECT_STATUS.TCP_RECEIVE_MSG:
                    _RxMsgDispatch.ProcessRxMsg((string)o);
                    break;
                default:
                    break;
            }
        }
        private bool _hasFtprun = false;
        private TcpCmdClient _TcpCmdClient = null;

        public void TcpSendMsg(string str)
        {
            if (string.IsNullOrEmpty(str) || _TcpCmdClient == null )
            {
                return;
            }
            _TcpCmdClient?.SendMsg(str);
        }

         public enum CONNECT_STATUS
        {
            DISCOVERY_INIT_OK,
            DISCOVERY_INIT_ERROR,
            DISCOVERY_GET_PCB,
            DISCOVERY_GET_PCB_CHANGE,
            DISCOVERY_END,

            TCP_CONNECT_ERROR,
            TCP_CONNECT_OK,
            TCP_RECEIVE_MSG,
            TCP_SEND_MSG_ERROR,
            TCP_RECV_MSG_ERROR,
            //
            FTP_OK,
            FTP_NG,
        }

        public delegate void UpdateUiDelegate(CONNECT_STATUS c, object[] oa);
        public UpdateUiDelegate UpdateUiHandler;


        
    }
}
