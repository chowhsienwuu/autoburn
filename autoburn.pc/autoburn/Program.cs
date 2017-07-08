using Autoburn.Ftp;
using Autoburn.Net;
using Autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoburn.MsgHandler;
using System.Threading;
using Autoburn.Manager;
using Autoburn.Ui;

namespace Autoburn
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!EnSureOnlyOneInstance())
            {
                SystemLog.E("程序", "已有程序在运行,本次启动失败");
                return;
            }

            SystemLog.I("程序", "信息准备初始化");
            DeviceManager.Instance.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
            var endpropt = "\n***************************************************\n" +
                 "***************************************************\n" +
                  "***************************************************\n";
            SystemLog.I("程序", "主程序退出");
            SystemLog.I("程序", endpropt);
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
