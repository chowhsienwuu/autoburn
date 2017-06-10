using FubarDev.FtpServer;
using FubarDev.FtpServer.AccountManagement;
using FubarDev.FtpServer.AccountManagement.Anonymous;
using FubarDev.FtpServer.FileSystem.DotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static autoburn.net.DeviceNetManager;

namespace autoburn.ftp
{
    public class FtpInstanceServer
    {
        public const string TAG = "FtpInstanceServer";
        private FtpServer _FtpServer = null;

        DotNetFileSystemProvider fsProvider;
        AnonymousMembershipProvider membershipProvider;
        string ipself;

        //there should only one ftpserver.
        public static readonly FtpInstanceServer instance = new FtpInstanceServer();

        private FtpInstanceServer()
        {
            membershipProvider = new AnonymousMembershipProvider(new NoValidation());
        }

        Thread _FtpThread = null;

        private AutoResetEvent _FtpThreadAutoResetEvent = new AutoResetEvent(false);
        public bool Start(string rootDir, string ipserver)
        {
            if (_HasInit)
            {
                Console.WriteLine("FtpServer already start");
                return true;
            }

            ipself = ipserver;
            if (!Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            fsProvider = new DotNetFileSystemProvider(rootDir);
            if (_FtpServer != null)
            {
                _FtpThreadAutoResetEvent.Reset();
                _FtpServer.Stop();
                _FtpServer.Dispose();
            }

            _FtpThread = new Thread(new ThreadStart(DoStart));
            _FtpThread.Start();

            return true;
        }

        private bool _HasInit = false;
      //  private bool _HasError = true;

        private void DoStart()
        {
            try
            {
                _FtpServer = new FtpServer(fsProvider, membershipProvider, ipself);
                Console.WriteLine("FtpServer new a instance");
                _FtpServer.Start();
                //_HasError = false;
                _HasInit = true;
                FtpServerStatusChangeeHandler?.Invoke(CONNECT_STATUS.FTP_OK, "FTP_OK");
                _FtpThreadAutoResetEvent.WaitOne();
                Console.WriteLine("FtpServer start");
            }
            catch (Exception e)
            {
                _HasInit = false;
              //  _HasError = true;
                Console.WriteLine("FtpServer error " + e.ToString());
                FtpServerStatusChangeeHandler?.Invoke(CONNECT_STATUS.FTP_NG, "FTP_NG");
            }
            //_FtpServer?.stat
        }

        public void Stop()
        {
            _HasInit = false;
            //_FtpThreadAutoResetEvent.Close();
            //_FtpThreadAutoResetEvent.Dispose();
            _FtpThreadAutoResetEvent.Set();
            _FtpServer?.Stop();
        }

        public delegate void FtpServerStatusChange(CONNECT_STATUS d, object o);
        public FtpServerStatusChange FtpServerStatusChangeeHandler;
    }
}
