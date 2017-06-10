using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.Manager
{
    class DeviceManager
    {
        public static readonly DeviceManager Instance = new DeviceManager();
        private DeviceManager()
        {
        }

        public void Init()
        {
            // init all manager .
            for (int i = 0; i < 30; i++)
            {
               // _ConfigManager.PutChooseChipHistoryItem("lanlan" + i);
            }
            _ConfigManager.GetSavedChooseChipHistory();
             _uaseAble = true;
        }
        
        private bool _uaseAble = false;
        public bool UseAble
        {
            get
            {
                return _uaseAble;
            }
        }

        private ChipSupportManager _ChipSupportManager = new ChipSupportManager();
        public ChipSupportManager ChipSupportManager
        {
            get
            {
                return _ChipSupportManager;
            }
        }

        private ConfigManager _ConfigManager = new ConfigManager();
        public ConfigManager ConfigManager
        {
            get
            {
                return _ConfigManager;
            }
        }
    }
}
