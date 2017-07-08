using Autoburn.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Autoburn.Manager
{
    class ConfigManager
    {
        public const string TAG = "ConfigManager";

        private string _configDir = ProgramInfo.CONFIGDIRPATH;

        private DeviceManager _DeviceManager = null;
        public ConfigManager(DeviceManager manager)
        {
            _DeviceManager = manager;
            //  InitXMLmodul();
            SystemLog.I(TAG, " 开始加载程序配置信息 ");
            LoadDataFromDataBase();
            SystemLog.I(TAG, " 开始加载程序信息结束 ");
        }

        private void LoadDataFromDataBase()
        {

        }

        public List<string> GetSavedChooseChipHistory()
        {
            List<string> historyname = new List<string>();

            var allhistry = _DeviceManager.DataBaseManager.GetConfigValue(ConfigInfo.TYPE_KEY_CHIPCHOOSEHISTORY);
            var histrylist = allhistry.Split(new[] { DeviceManager.MultStringSpitString }, StringSplitOptions.None);

            foreach (string item in histrylist)
            {
                if (item.Length > 1)
                {
                    historyname.Add(item);
                }
            }

            historyname.Reverse();
            return historyname;
        }

        public void PutChooseChipHistoryItem(string history)
        {
            var allhistry = _DeviceManager.DataBaseManager.GetConfigValue(ConfigInfo.TYPE_KEY_CHIPCHOOSEHISTORY);
            var histrylist = allhistry.Split(new[] { DeviceManager.MultStringSpitString }, StringSplitOptions.None);

            List<string> historyname = new List<string>(histrylist);
            while (historyname.Capacity > 10)
            {
                historyname.RemoveAt(0);
            }
            historyname.Add(history);

            var newvalue = "";
            foreach (string name in historyname)
            {
                if (name.Length > 1)
                {
                    newvalue += name + DeviceManager.MultStringSpitString;
                }
            }

            _DeviceManager.DataBaseManager.ExeSetKeyVal(ConfigInfo.TYPE_KEY_CHIPCHOOSEHISTORY, newvalue);
        }


#if USE_XML_CONFIG
        #region storeinxml not use by now. 
        private void InitXMLmodul()
        {
            if (!Directory.Exists(_configDir))
            {
                Directory.CreateDirectory(_configDir);
            }
            var f = new FileInfo(ProgramInfo.CONFIGFILE);
            if (!f.Exists)
            {
                // init a xml file.
                XmlTextWriter InitXmlTextWriter = new XmlTextWriter(ProgramInfo.CONFIGFILE, null);
                InitXmlTextWriter.Formatting = Formatting.Indented;
                InitXmlTextWriter.WriteStartDocument(true);
                InitXmlTextWriter.WriteStartElement(ConfigInfo.TYPE_TABLENAME);
                InitXmlTextWriter.WriteAttributeString(ConfigInfo.TYPE_CREATETIME, DateTime.Now.ToString());
                InitXmlTextWriter.WriteAttributeString(ConfigInfo.TYPE_VERSION, Assembly.GetExecutingAssembly().GetName().Version.ToString());

                InitXmlTextWriter.WriteEndElement();
                InitXmlTextWriter.Flush();
                InitXmlTextWriter.Close();
                InitXmlTextWriter.Dispose();
            }

            _xmlDocument.Load(ProgramInfo.CONFIGFILE);
        }
       private XmlDocument _xmlDocument = new XmlDocument();

        public List<string> GetSavedChooseChipHistory()
        {
            List<string> historyname = new List<string>();
            var chiphistorynode = _xmlDocument.SelectSingleNode(_chiphistoryel);
            var historyitem = chiphistorynode?.SelectNodes(_chiphistoryel + "/" + ConfigInfo.TYPE_CHIPCHOOSEHISTORYITEM);
            if (historyitem != null)
            {
                foreach (XmlNode itemnode in historyitem)
                {
                    var itemel = itemnode as XmlElement;
                    historyname.Add(itemel.GetAttribute(ConfigInfo.TYPE_A_CHIPCHOOSEHISTORYNAME));
                }
            }
            historyname.Reverse();
            return historyname;
        }

        private string _chiphistoryel = "/" + ConfigInfo.TYPE_TABLENAME + "/" + ConfigInfo.TYPE_CHIPCHOOSEHISTORY;
        public void PutChooseChipHistoryItem(string history)
        {
            if (String.IsNullOrEmpty(history))
            {
                return;
            }
            var chiphistorynode = _xmlDocument.SelectSingleNode(_chiphistoryel);
            if (chiphistorynode == null)
            { //not exist create a node .
                var rootnode = _xmlDocument.SelectSingleNode(ConfigInfo.TYPE_TABLENAME);
                var historyroot = _xmlDocument.CreateElement(ConfigInfo.TYPE_CHIPCHOOSEHISTORY);
                rootnode?.AppendChild(historyroot);
            }
            chiphistorynode = _xmlDocument.SelectSingleNode(_chiphistoryel);

            var historyitemlist = chiphistorynode?.SelectNodes(_chiphistoryel + "/" + ConfigInfo.TYPE_CHIPCHOOSEHISTORYITEM);
            for (int i = 0; i < historyitemlist.Count; i++)
            {
                if (i < historyitemlist.Count - 10)
                { //去多.
                    chiphistorynode.RemoveChild(historyitemlist[i]);
                    //_xmlDocument.RemoveChild(historyitemlist[i]);
                }
                else
                {//去重
                    var itemel = historyitemlist[i] as XmlElement;
                    if (history.Equals(itemel.GetAttribute(ConfigInfo.TYPE_A_CHIPCHOOSEHISTORYNAME)))
                    {
                        chiphistorynode.RemoveChild(itemel);
                    }
                }
            }
            //  historyitemlist = chiphistorynode?.SelectNodes(_chiphistoryel + "/" + ConfigInfo.TYPE_E_CHIPCHOOSEHISTORYITEM);
            //     forea

            var historyitem = _xmlDocument.CreateElement(ConfigInfo.TYPE_CHIPCHOOSEHISTORYITEM);
            var historyitemname = _xmlDocument.CreateAttribute(ConfigInfo.TYPE_A_CHIPCHOOSEHISTORYNAME);
            historyitemname.Value = history;
            historyitem.Attributes.Append(historyitemname);
            chiphistorynode?.AppendChild(historyitem);
            _xmlDocument.Save(ProgramInfo.CONFIGFILE);
        }
        #endregion xmlmodel 
#endif
    }
}

