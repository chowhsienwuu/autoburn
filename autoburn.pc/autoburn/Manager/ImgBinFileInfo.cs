using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class ImgBinFileInfo: EventArgs
    {
        public const int FILE_TYPE_DEFAULT = 0x0;
        private int _ImageBinFileType = FILE_TYPE_DEFAULT;

        private string _ImageBinFileFullPath = string.Empty;
        private string _ImageBinFileName = string.Empty;
        private string _ImageBinFileMD5Sum = string.Empty;
        private long _ImageBinFileLen = 0;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("file fullpath " + _ImageBinFileFullPath + Environment.NewLine);
            sb.Append("file _ImageBinFileName " + _ImageBinFileName + Environment.NewLine);
            sb.Append("file _ImageBinFileMD5Sum " + _ImageBinFileMD5Sum + Environment.NewLine);
            sb.Append("file _ImageBinFileLen " + _ImageBinFileLen + Environment.NewLine);
            sb.Append("file _ImageBinFileType " + _ImageBinFileType + Environment.NewLine);
            return sb.ToString();
        }

        public string ImageBinFileFullPath
        {
            get
            {
                return _ImageBinFileFullPath;
            }

            set
            {
                _ImageBinFileFullPath = value;
            }
        }

        public string ImageBinFileName
        {
            get
            {
                return _ImageBinFileName;
            }

            set
            {
                _ImageBinFileName = value;
            }
        }

        public string ImageBinFileMD5Sum
        {
            get
            {
                return _ImageBinFileMD5Sum;
            }

            set
            {
                _ImageBinFileMD5Sum = value;
            }
        }

        public long ImageBinFileLen
        {
            get
            {
                return _ImageBinFileLen;
            }

            set
            {
                _ImageBinFileLen = value;
            }
        }
    }
}
