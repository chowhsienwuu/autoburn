using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    public class ProjectInfo
    {
        public const string TYPE_E_PROJECT = "project";
        public const string TYPE_A_CREATETIME = "createtime";
        public const string TYPE_A_VERVERSION = "version";
        public const string TYPE_E_PROJECTNAME = "projectname";

        public const string TYPE_E_CHIP = "chip";
        public const string TYPE_A_CHIPNAME = "chipname";

        public const string TYPE_E_FILE = "file";
        public const string TYPE_A_FILENAME = "filename";
        public const string TYPE_A_SIZE = "size";

        private string createtime;
        private string version;
        private string projectname;
        private string chipname;
        private string size;
        private string filename;

        public string Createtime
        {
            get
            {
                return createtime;
            }

            set
            {
                createtime = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public string Projectname
        {
            get
            {
                return projectname;
            }

            set
            {
                projectname = value;
            }
        }

        public string Chipname
        {
            get
            {
                return chipname;
            }

            set
            {
                chipname = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
            }
        }
    }
}
