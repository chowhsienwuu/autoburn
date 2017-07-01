using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn
{
    class ProgramInfo
    {
        public const int PC_UDP_LISTEN_PORT = 18000;
        public const int PCB_TCP_SERVER_LISTEN_PORT = 28001;

        public static string CurrentPath = System.Environment.CurrentDirectory;
        
        public static string FTPDIR = "file";
        public static string FtpServerRootPath = CurrentPath + FTPDIR;

        public static string PCIPaddr;
        public static IPEndPoint PCBIPAddrEndPoint;


        private void getIP()
        {
           var  mCurrentPath = System.Environment.CurrentDirectory;

            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
        }

        public static string CHIPINFODIR = "chipinfo";
        public static string CHIPINFODIRPATH = CurrentPath +"\\" + CHIPINFODIR;

        public static string CONFIGDIR = "cfg";
        public static string CONFIGDIRPATH = CurrentPath + @"\" + CONFIGDIR;
        public static string CONFIGFILE = CONFIGDIRPATH + @"\" + "save.xml";

        public static string PROJECTFILE_EXTENDSNAME = ".ccp";

        public static string DBFILE = "raw.db";
        public static string DBFILEPATH = CurrentPath + @"\";
        public static string DBFILEFULLPATHFILE = DBFILEPATH + @"\" + DBFILE;

    }
}
