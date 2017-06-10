using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.Manager
{
    class ConfigInfo
    {
        // head.
        public const string TYPE_E_CONFIG = "config";
        public const string TYPE_A_CREATETIME = "createtime";
        public const string TYPE_A_VERSION = "version";

        //记录选择芯片的历史记录
        public const string TYPE_E_CHIPCHOOSEHISTORY = "chipchoosehistory";
        public const string TYPE_E_CHIPCHOOSEHISTORYITEM = "chipchoosehistoryitem";
        public const string TYPE_A_CHIPCHOOSEHISTORYNAME = "name";
    }
}
