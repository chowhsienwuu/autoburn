using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.util
{
    //程序运行的信息,打印debug等信息.
    public class ProgLog
    {
        private const string TAG = "logConsole";
        private static Logger _logger = LogManager.GetLogger(TAG);
        public static void D(string tag = null, object o = null)
        {
            if (tag == null)
            {
                tag = string.Empty;
            }
            if (o == null)
            {
                o = string.Empty;
            }
            Console.WriteLine("{0}  :  {1}", tag, o);
            _logger.Log(LogLevel.Debug, "  " + tag + "-" +  o.ToString());
        }
    }
}
