using Autoburn.MsgHandler;
using Autoburn.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    public  class DeviceManager
    {
        public const string TAG = "DeviceManager";
        public static readonly DeviceManager Instance = new DeviceManager();
        public const string MultStringSpitString = "$$$$$$";

        private DeviceManager()
        {
            var startpropt = "\n--------------------------------------------\n" +
                                "--------------------------------------------\n" +
                                "--------------------------------------------\n" +
                                "--------------------------------------------\n";
            SystemLog.I("程序", "准备启动");
            SystemLog.I("程序", startpropt);

            ProgLog.D(TAG, " DeviceManager init..");
            _dataBaseManager = new DataBaseManager(this);
            _ChipSupportManager = new ChipSupportManager(this);
            _ConfigManager = new ConfigManager(this);
            _projectManager = new ProjectManager();
            _WrapAdbManager = new WarpAdbManager(this);
            ProgLog.D(TAG, " DeviceManager end..");
        }


        NettyJsonCmdManager _NettyJsonCmdManager = null;
        public NettyJsonCmdManager NettyJsonCmdManager
        {
            get
            {
                return _NettyJsonCmdManager;
            }
            set
            {
                _NettyJsonCmdManager = value;

                RxMsgDispatch = new RxMsgDispatch(this);
                //start the server.
                // _NettyJsonCmdManager?.Start();
            }
        }

        private RxMsgDispatch _RxmsgDispatch = null;
        public RxMsgDispatch RxMsgDispatch
        {
            get
            {
                return _RxmsgDispatch;
            }
            set
            {
                _RxmsgDispatch = value;
            }
        }

        public void Stop()
        {
            _WrapAdbManager.Stop();
        }

        public void Init()
        {
            _uaseAble = true;
        }

        private WarpAdbManager _WrapAdbManager = null;


        private DataBaseManager _dataBaseManager = null;
        internal DataBaseManager DataBaseManager
        {
            get
            {
                return _dataBaseManager;
            }
        }

        private bool _uaseAble = false;
        public bool UseAble
        {
            get
            {
                return _uaseAble;
            }
        }

        private ChipSupportManager _ChipSupportManager = null;
        public ChipSupportManager ChipSupportManager
        {
            get
            {
                return _ChipSupportManager;
            }
        }

        private ConfigManager _ConfigManager = null;
        public ConfigManager ConfigManager
        {
            get
            {
                return _ConfigManager;
            }
        }

        public ProjectManager ProjectManager
        {
            get
            {
                return _projectManager;
            }

            set
            {
                _projectManager = value;
            }
        }

        internal WarpAdbManager WrapAdbManager
        {
            get
            {
                return _WrapAdbManager;
            }

            set
            {
                _WrapAdbManager = value;
            }
        }



        private ProjectManager _projectManager = null;
    }
}
