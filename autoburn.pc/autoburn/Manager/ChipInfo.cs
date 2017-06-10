using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoburn.Manager
{
    class ChipInfo
    {
        //      <chipinfo vendor = "jsc" series="JSFXX">
        //<chip name = "JSFA9A2N73ABB-450" type="emmc" package="bma107" burner="ZY-DB107A0-A01" note="">  </chip>
        public const string TYPE_E_CHIPINFO = "chipinfo";
        public const string TYPE_A_VENDOR = "vendor";
        public const string TYPE_A_SERIES = "series";
        public const string TYPE_E_CHIP = "chip";
        public const string TYPE_A_NAME = "name";
        public const string TYPE_A_TYPE = "type";
        public const string TYPE_A_PACKAGE = "package";
        public const string TYPE_A_BURNER = "burner";
        public const string TYPE_A_NOTE = "note";

        private string _vendor;
        public string vendor
        {
            get
            {
                return _vendor;
            }
            set
            {
                _vendor = value;
            }
        }

        private string _series;
        public string series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
            }
        }
       
        private string _burner;
        public string burner
        {
            get
            {
                return _burner;
            }
            set
            {
                _burner = value;
            }
        }
        private string _note;
        public string note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _type;
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private string _package;
        public string package
        {
            get
            {
                return _package;
            }
            set
            {
                _package = value;
            }
        }
    }
}
