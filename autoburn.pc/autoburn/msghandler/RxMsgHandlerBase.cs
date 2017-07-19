using Autoburn.Manager;
using Autoburn.Net;
using Autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.MsgHandler
{
    public abstract class RxMsgHandlerBase :MsgBase
    {
        private new string TAG = "RxMsgHandlerBase";

        public string Type;
        protected DeviceManager devicesmanager;
        public RxMsgHandlerBase(DeviceManager d,  string type)
        {
            devicesmanager = d;
            Type = type;
        }
        public virtual void Process() {
            D("msghandler msg " + Msg);
        }

        public string Msg;
    }
}
