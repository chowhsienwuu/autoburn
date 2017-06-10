using autoburn.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using autoburn.Net;

namespace autoburn.MsgHandler
{
    public class RxMsgDispatch
    {
        private string TAG = "RxMsgDispatch";
        private void D(object o)
        {
            ProgLog.D(TAG, o);
        }

        private HashSet<string> _SupportRxMsg = new HashSet<string>();
        private DeviceNetManager deviceNetManager;

        private void AddHandler()
        {
            _SupportRxMsg.Clear();
            _SupportRxMsg.Add(new RxMsgHandlerInfo(deviceNetManager).Type);
            _SupportRxMsg.Add(new RxMsgHandlerTest(deviceNetManager).Type);
        }

        public RxMsgDispatch()
        {
            AddHandler();
        }

        public RxMsgDispatch(DeviceNetManager deviceNetManager):this()
        {
            this.deviceNetManager = deviceNetManager;
        }

        public void Stop()
        {
            _SupportRxMsg?.Clear();

        }

        public void ProcessRxMsg(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            RxMsgHandlerBase rxMsgHandler = null;
            try
            {
                JObject obj = JObject.Parse(str);
                string msgtype = obj[MsgBase.MSG_TYPE_STRING].ToString();
                if (!_SupportRxMsg.Contains(msgtype))
                {
                 //   return;
                }
                D("the msgtype is " + msgtype);
                    switch (msgtype)
                    {
                        case MsgBase.MSG_TYPE_INFO:
                            rxMsgHandler = new RxMsgHandlerInfo(deviceNetManager);
                            
                            break;
                        case MsgBase.MSG_TYPE_TEST:
                        rxMsgHandler = new RxMsgHandlerTest(deviceNetManager);
                        break;
                        default:
                            break;
                    }
    
                if (rxMsgHandler != null)
                {
                    rxMsgHandler.Msg = str;
                }
            }
            catch { }
 
            if (rxMsgHandler != null)
            {
                Task.Run(new Action(rxMsgHandler.Process));
            }
        }
    }
}
