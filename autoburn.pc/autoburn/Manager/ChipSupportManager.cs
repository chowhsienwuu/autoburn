using Autoburn.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Autoburn.Manager
{
    class ChipSupportManager
    {
        public const string TAG = "ChipSupportManager";
        private string _chipinfodir = ProgramInfo.CHIPINFODIRPATH;

        private DeviceManager _DeviceManager = null;
        internal ChipSupportManager(DeviceManager manager)
        {
            _DeviceManager = manager;
            //InitXMLmodul();
            SystemLog.I(TAG, "芯片列表信息开始初始化");
            InitDBmodul();
            SystemLog.I(TAG, "芯片列表信息初始化完成");
        }

        private void InitDBmodul()
        {
            var sql = "select * from " + ChipInfo.TYPE_TABLE_NAME_CHIPINFO + ";";
            var read = _DeviceManager.DataBaseManager.ExeGetReader(sql);
            if (read == null || !read.HasRows)
            {
                return;
            }
            _venderseriesDictionary.Clear();
            _allchipvendorlistDic.Clear();
            _allChipInfo.Clear();

            while (read.Read())
            {            
                try
                {
                    var chipinfo = new ChipInfo();
                    NameValueCollection nv = read.GetValues();
                    chipinfo.vendor = "" + nv.Get(ChipInfo.TYPE_COLUMN_VENDOR);
                    var series = nv.Get(ChipInfo.TYPE_COLUMN_SERIES);

                    chipinfo.series = "" + nv.Get(ChipInfo.TYPE_COLUMN_SERIES);
                    chipinfo.name = nv.Get(ChipInfo.TYPE_COLUMN_NAME);
                    chipinfo.type = nv.Get(ChipInfo.TYPE_COLUMN_TYPE);
                    chipinfo.package = nv.Get(ChipInfo.TYPE_COLUMN_PACKAGE);
                    chipinfo.burner = nv.Get(ChipInfo.TYPE_COLUMN_BURNER);
                    chipinfo.note = nv.Get(ChipInfo.TYPE_COLUMN_NOTE);

                    _allChipInfo.Add(chipinfo);

                    ProgLog.D(TAG, chipinfo.ToString());
                }
                catch (Exception e)
                {
                    SystemLog.E(TAG, " get chipinfo error " + e.ToString());
                }
            }
            read.Close();
        }

        private List<ChipInfo> _allChipInfo = new List<ChipInfo>();
        public List<ChipInfo> AllChipInfo
        {
            get
            {
                return _allChipInfo;
            }
        }

        public Dictionary<string, object[]> VenderseriesDictionary
        {
            get
            {
                return _venderseriesDictionary;
            }
        }
        //key-value vendor文件夹, - 文件夹中的文件列表.  
        private Dictionary<string, object[]> _venderseriesDictionary = new Dictionary<string, object[]>();







        #region storeinxml not use by now. 
        private void InitXMLmodul()
        {
            LoadVendor();
            foreach (KeyValuePair<string, object[]> kvp in _venderseriesDictionary)
            {
                // TreeNode tn = new TreeNode(kvp.Key, seriesTreeNodelist.ToArray());
                foreach (object series in kvp.Value)
                {
                    //seriesTreeNodelist.Add(new TreeNode(series.ToString()));
                    var chipinfolist = DoGetChipInfo(kvp.Key, series.ToString());
                    _allchipvendorlistDic.Add(new KeyValuePair<string, string>(kvp.Key, series.ToString()), chipinfolist);
                }
            }
        }
        private void LoadVendor()
        {
            DirectoryInfo folder = new DirectoryInfo(_chipinfodir);
          //  var file = folder.EnumerateFiles();
            var dirinfo = folder.EnumerateDirectories();
            foreach(DirectoryInfo info in dirinfo)
            {
                var files = info.EnumerateFiles("*.xml");
                ArrayList tempserise = new ArrayList();
                foreach (FileInfo f in files)
                {
                    tempserise.Add(f.Name.Replace(f.Extension, ""));
                }
                if (tempserise.Count > 0)
                {
                    tempserise.TrimToSize();
                    _venderseriesDictionary.Add(info.Name, tempserise.ToArray());   
                }
            }
        }

        private Dictionary<KeyValuePair<string, string>, List<ChipInfo>> _allchipvendorlistDic = 
            new Dictionary<KeyValuePair<string, string>, List<ChipInfo>>();

        public List<ChipInfo> GetChipInfo(string vendor, string serise)
        {
            foreach (KeyValuePair<KeyValuePair<string, string>, List<ChipInfo>> kvp in _allchipvendorlistDic)
            {
                if (kvp.Key.Key.Equals(vendor) && kvp.Key.Value.Equals(serise))
                {
                    return kvp.Value;
                }
            }
            return null;
        }
        public List<ChipInfo> GetAllChipInfo()
        {
            List<ChipInfo> alllistinfo = new List<ChipInfo>();
            foreach (KeyValuePair<KeyValuePair<string, string>, List<ChipInfo>> kvp in _allchipvendorlistDic)
            {
                alllistinfo.AddRange(kvp.Value);
            }
            return alllistinfo;
        }

        private List<ChipInfo> DoGetChipInfo(string vendor, string serise)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释

            XmlDocument doc = new XmlDocument();
            List<ChipInfo> infolist = new List<ChipInfo>();
            try
            {
                doc.Load(_chipinfodir + @"\" + vendor + @"\" + serise + ".xml");
                var chipinfosiglenode = doc.SelectSingleNode(ChipInfo.TYPE_TABLE_NAME_CHIPINFO);
                var chipinfoElement = chipinfosiglenode as XmlElement;
                chipinfoElement.GetAttribute(ChipInfo.TYPE_COLUMN_VENDOR);

                // parse every chip. in the em
                XmlNodeList xnl = chipinfosiglenode.ChildNodes;
                foreach(XmlNode xmlnode in xnl)
                {
                    var siglechipele = xmlnode as XmlElement;
                    ChipInfo chipinfoobject = new ChipInfo();
                    chipinfoobject.vendor = vendor;
                    chipinfoobject.series = serise;

                    chipinfoobject.name = siglechipele.GetAttribute(ChipInfo.TYPE_COLUMN_NAME);
                    chipinfoobject.type = siglechipele.GetAttribute(ChipInfo.TYPE_COLUMN_TYPE);
                    chipinfoobject.package = siglechipele.GetAttribute(ChipInfo.TYPE_COLUMN_PACKAGE);
                    chipinfoobject.burner = siglechipele.GetAttribute(ChipInfo.TYPE_COLUMN_BURNER);
                    chipinfoobject.note = siglechipele.GetAttribute(ChipInfo.TYPE_COLUMN_NOTE);
                    infolist.Add(chipinfoobject);
                }
            }
            catch
            {

            }
            finally
            {
               
            }
           
            return infolist;
        }
        #endregion storeinxml not use by now. 
    }
}
