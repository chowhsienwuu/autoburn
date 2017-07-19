using Autoburn.Manager;
using Autoburn.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.MsgHandler
{
    class RxMsgHandlerInfo:RxMsgHandlerBase
    {
        public RxMsgHandlerInfo(DeviceManager d) : base(d, MSG_TYPE_INFO)
        {
        }
        public override void Process()
        {
            base.Process();
            if (string.IsNullOrEmpty(Msg))
            {
                return;
            }


        }
    }
}
