using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class DeviceManager
    {
        public static readonly DeviceManager Instance = new DeviceManager();


        private DeviceManager()
        {
            _dataBaseManager = new DataBaseManager(this);
            _ChipSupportManager = new ChipSupportManager(this);
            _ConfigManager = new ConfigManager(this);
            _projectManager = new ProjectManager();
        }

        public void Init()
        {
            // init all manager .
            //for (int i = 0; i < 30; i++)
            //{
            //   // _ConfigManager.PutChooseChipHistoryItem("lanlan" + i);
            //}
            //_ConfigManager.GetSavedChooseChipHistory();
            _uaseAble = true;
        }

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

        private ProjectManager _projectManager = null;

    }
}
