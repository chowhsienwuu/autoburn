using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Autoburn.Manager
{
    class ChipSupportManager
    {
        private string _chipinfodir =ProgramInfo.CHIPINFODIRPATH;

        private DeviceManager _DeviceManager = null;
        internal ChipSupportManager(DeviceManager manager)
        {
            _DeviceManager = manager;
            //InitXMLmodul();
            InitDBmodul();
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
                 //   Console.Out.WriteLine(" " + read[ChipInfo.TYPE_VENDOR]);
                    chipinfo.vendor = read[ChipInfo.TYPE_VENDOR].ToString();
                    chipinfo.series = read[ChipInfo.TYPE_SERIES].ToString();
                    chipinfo.name = read[ChipInfo.TYPE_NAME].ToString();
                    chipinfo.type = read[ChipInfo.TYPE_TYPE].ToString();
                    chipinfo.package = read[ChipInfo.TYPE_PACKAGE].ToString();
                    chipinfo.burner = read[ChipInfo.TYPE_BURNER].ToString();
                    chipinfo.note = read[ChipInfo.TYPE_NOTE].ToString();
                    _allChipInfo.Add(chipinfo);
                }
                catch { }
            }
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
                chipinfoElement.GetAttribute(ChipInfo.TYPE_VENDOR);

                // parse every chip. in the em
                XmlNodeList xnl = chipinfosiglenode.ChildNodes;
                foreach(XmlNode xmlnode in xnl)
                {
                    var siglechipele = xmlnode as XmlElement;
                    ChipInfo chipinfoobject = new ChipInfo();
                    chipinfoobject.vendor = vendor;
                    chipinfoobject.series = serise;

                    chipinfoobject.name = siglechipele.GetAttribute(ChipInfo.TYPE_NAME);
                    chipinfoobject.type = siglechipele.GetAttribute(ChipInfo.TYPE_TYPE);
                    chipinfoobject.package = siglechipele.GetAttribute(ChipInfo.TYPE_PACKAGE);
                    chipinfoobject.burner = siglechipele.GetAttribute(ChipInfo.TYPE_BURNER);
                    chipinfoobject.note = siglechipele.GetAttribute(ChipInfo.TYPE_NOTE);
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
