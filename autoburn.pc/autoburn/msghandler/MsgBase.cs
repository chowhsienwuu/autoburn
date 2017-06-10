using autoburn.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.MsgHandler
{
   public abstract class MsgBase
    {
        // const  发送接收json数据包要用到的常量
        public const string MSG_TYPE_STRING = "msgtype";
        public const string MSG_INDEX = "msgindex";


        //
        public const string MSG_TYPE_INFO = "info";
        public const string MSG_TYPE_TEST = "test";
        // 

        protected virtual string TAG => "MsgBase";
        protected void D(object o)
        {
            ProgLog.D(TAG, o);
        }

    }
}
