using autoburn.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.msghandler
{
     public class TxMsgBase :MsgBase
    {

        protected new string TAG => "TxMsgBase";

        private string _Type;
        private static int _index = 1;
        protected JObject _JsonObject = new JObject();
        public TxMsgBase(string Type)
        {
            this._Type = Type;
            _JsonObject[MSG_TYPE_STRING] = _Type;
            _JsonObject[MSG_INDEX] = _index++;
            D(TAG + "---new a TxmsgBase " + this._Type);
        }

        public TxMsgBase AddATAG(string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
            {
                return this;
            }
            _JsonObject[key] = value;
            return this;
        }

        public override string ToString()
        {
            return _JsonObject.ToString();
        }
    }
}
