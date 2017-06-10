using autoburn.Net;
using autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.MsgHandler
{
    public abstract class RxMsgHandlerBase :MsgBase
    {
        private new string TAG = "RxMsgHandlerBase";

        public string Type;
        protected DeviceNetManager devicesNetmanager;
        public RxMsgHandlerBase(DeviceNetManager d,  string type)
        {
            devicesNetmanager = d;
            Type = type;
        }
        public virtual void Process() {
            D("msghandler msg " + Msg);
        }

        public string Msg;
    }
}
