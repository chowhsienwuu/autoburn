using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.util
{
    public class ProgLog
    {
        private const string TAG = "logConsole";
        private static Logger _logger = LogManager.GetLogger(TAG);
        public static void D(string tag = null, object o = null)
        {
            Console.WriteLine("{0}  :  {1}", tag, o);
            _logger.Log(LogLevel.Debug, "" + tag + o.ToString());
        }
    }
}
