using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.util
{
    public class SystemLog
    {
        public const string TAG = "systemlog";
        private static Logger _logger = LogManager.GetLogger(TAG);

        public static void I(object tag, object msg)
        {
            _logger.Info(tag.ToString() + msg.ToString());

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
