using Autoburn.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoburn.Net;
using Autoburn.Manager;

namespace Autoburn.MsgHandler
{
    public class RxMsgDispatch
    {
        private string TAG = "RxMsgDispatch";

        private HashSet<string> _SupportRxMsg = new HashSet<string>();
        private DeviceManager deviceManager;

        private void AddHandler()
        {
            _SupportRxMsg.Clear();
            _SupportRxMsg.Add(new RxMsgHandlerInfo(deviceManager).Type);
            _SupportRxMsg.Add(new RxMsgHandlerTest(deviceManager).Type);
        }

        private RxMsgDispatch()
        {
            AddHandler();
        }

        public RxMsgDispatch(DeviceManager deviceManager) : this()
        {
            this.deviceManager = deviceManager;
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
                ProgLog.D(TAG, "the msgtype is " + msgtype);
                switch (msgtype)
                {
                    case MsgBase.MSG_TYPE_INFO:
                        rxMsgHandler = new RxMsgHandlerInfo(deviceManager);
                        break;
                    case MsgBase.MSG_TYPE_TEST:
                        rxMsgHandler = new RxMsgHandlerTest(deviceManager);
                        break;
                    default:
                        break;
                }

                if (rxMsgHandler != null)
                {
                    rxMsgHandler.Msg = str;
                }
            }
            catch (Exception e)
            {
                ProgLog.D(TAG, "ProcessRxMsg error: " + e.ToString());
            }

            if (rxMsgHandler != null)
            {
                Task.Run(new Action(rxMsgHandler.Process));
            }
        }
    }
}
