using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace autoburn.Manager
{
    class ChipSupportManager
    {
        private string _chipinfodir =ProgramInfo.CHIPINFODIRPATH;
         internal ChipSupportManager()
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

        public Dictionary<string, object[]> VenderseriesDictionary
        {
            get
            {
                return _venderseriesDictionary;
            }
        }

        //key-value vendor文件夹, - 文件夹中的文件列表. 
        private Dictionary<string, object[]> _venderseriesDictionary = new Dictionary<string, object[]>();
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

        public List<ChipInfo> DoGetChipInfo(string vendor, string serise)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释

            XmlDocument doc = new XmlDocument();
            List<ChipInfo> infolist = new List<ChipInfo>();
            try
            {
                doc.Load(_chipinfodir + @"\" + vendor + @"\" + serise + ".xml");
                var chipinfosiglenode = doc.SelectSingleNode(ChipInfo.TYPE_E_CHIPINFO);
                var chipinfoElement = chipinfosiglenode as XmlElement;
                chipinfoElement.GetAttribute(ChipInfo.TYPE_A_VENDOR);

                // parse every chip. in the em
                XmlNodeList xnl = chipinfosiglenode.ChildNodes;
                foreach(XmlNode xmlnode in xnl)
                {
                    var siglechipele = xmlnode as XmlElement;
                    ChipInfo chipinfoobject = new ChipInfo();
                    chipinfoobject.vendor = vendor;
                    chipinfoobject.series = serise;

                    chipinfoobject.name = siglechipele.GetAttribute(ChipInfo.TYPE_A_NAME);
                    chipinfoobject.type = siglechipele.GetAttribute(ChipInfo.TYPE_A_TYPE);
                    chipinfoobject.package = siglechipele.GetAttribute(ChipInfo.TYPE_A_PACKAGE);
                    chipinfoobject.burner = siglechipele.GetAttribute(ChipInfo.TYPE_A_BURNER);
                    chipinfoobject.note = siglechipele.GetAttribute(ChipInfo.TYPE_A_NOTE);
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


    }
}
