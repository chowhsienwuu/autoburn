using autoburn.Ftp;
using autoburn.Net;
using autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoburn.MsgHandler;
using System.Threading;
using autoburn.Manager;

namespace autoburn
{
    static class Program
    {

        public static string mCurrentPath = "";
        static int index = 0;
        static void test()
        {
            while (true)
            {

            Thread.Sleep(100);
                ProgLog.D("test..", " +proglog_====" + index++);
                SystemLog.I("test", "-system.-" + index++);
            }

        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
    //    [STAThread]
        static void Main()
        {

            //RxMsgDispatch rd = new RxMsgDispatch();
            //string str = "{\"msgtype\":\"Test\", \"gogo\":\"98\"}";
            // rd.ProcessRxMsg(str);
            //TxMsgBase t = new TxMsgBase("lan");
            //Console.WriteLine("t.tosring " + t);

            //Thread testThead = new Thread(new ThreadStart(test));
            //testThead.Start();

            //return;

            SystemLog.I("程序", "准备启动");
            if (!EnSureOnlyOneInstance())
            {
                SystemLog.E("程序", "已有程序在运行,本次启动失败");
                return;
            }

            DeviceManager.Instance.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        static bool EnSureOnlyOneInstance()
        {
            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(null, "程序已在运行，请不要同时运行多个本程序。即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret;
        }
    }
}
