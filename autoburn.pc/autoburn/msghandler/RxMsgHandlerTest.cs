using autoburn.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.MsgHandler
{
    class RxMsgHandlerTest : RxMsgHandlerBase
    {
        public RxMsgHandlerTest(DeviceNetManager d) : base(d, MSG_TYPE_TEST)
        {
        }
        public override void Process()
        {
            base.Process();
            if (string.IsNullOrEmpty(Msg))
            {
                return;
            }
            D("..just for test");

        }
    }
}
