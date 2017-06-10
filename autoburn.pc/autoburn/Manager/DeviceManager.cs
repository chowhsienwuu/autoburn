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

            _ChipSupportManager = new ChipSupportManager();
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

        private ChipSupportManager _ChipSupportManager;
        
        public ChipSupportManager ChipSupportManager
        {
            get
            {
                return _ChipSupportManager;
            }
        }


    }
}
