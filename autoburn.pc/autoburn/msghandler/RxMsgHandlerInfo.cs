using autoburn.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.msghandler
{
    class RxMsgHandlerInfo:RxMsgHandlerBase
    {
        public RxMsgHandlerInfo(DeviceNetManager d) : base(d, MSG_TYPE_INFO)
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
