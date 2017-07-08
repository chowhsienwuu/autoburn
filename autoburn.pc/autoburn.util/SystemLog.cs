using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.util
{
    public class SystemLog
    {
        public const string TAG = "systemlog";
        private static Logger _logger = LogManager.GetLogger(TAG);
      //  工程运行的信息,打印debug等信息.
        public static void I(object tag, object msg)
        {
            _logger.Info(tag.ToString() + msg.ToString());
            //_logger.
            //this is for debug
            ProgLog.D(TAG + tag.ToString(), msg);
        }

        public static void E(object tag, object msg)
        {
            _logger.Info(tag.ToString() + msg.ToString());

            //this is for debug
            ProgLog.D(TAG + tag.ToString(), msg);
        }
    }
}
