using Autoburn.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Autoburn.Manager
{
    public class ProjectManager
    {
        public const string TAG = "ProjectManager";
        private string _configDir = ProgramInfo.CONFIGDIRPATH;
        public ProjectManager()
        {
            // Init();
            SystemLog.I(TAG, "芯片列表信息开始初始化");
            SystemLog.I(TAG, "芯片列表信息初始化完成");
        }

        public void ReSet()
        {
            SystemLog.I(TAG, "ReSET工程");
        }

        private string _fuallpathdir = "";
        private string _dbfile = "";
        public void InitDir(string fullpath)
        {
            _fuallpathdir = fullpath;
            _dbfile = fullpath + @"/" + ProjectInfo.PROJECT_DB_FILE_NAME;
            // create a db. create table.
            SystemLog.I(TAG, "工程路径: "　+ _fuallpathdir);
            SystemLog.I(TAG, "工程database: " + _dbfile);

            CreateDbFile();
            connectToDatabase();
            CreateTable();
        }

        SQLiteConnection _dbConnection;
        private void connectToDatabase()
        {
            var sql = "Data Source=" + _dbfile + ";Version=3;";
            _dbConnection = new SQLiteConnection(sql);
            _dbConnection.Open();

            //add a key create time.
        }

        public Hashtable GetCurrentProjectConfig()
        {
            Hashtable hashtable = new Hashtable();
            var sql = "select * from project;";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    hashtable[reader[ProjectInfo.TYPE_COLUMN_KEY]] = reader[ProjectInfo.TYPE_COLUMN_VALUE];
                }
                reader.Close();
            }
            return hashtable;
        }

        private void CreateTable()
        {
            string sql = "CREATE TABLE \"project\"([index] INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,[key]NOT NULL, [value]);";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
        }

        private void CreateDbFile()
        {
            if (File.Exists(_dbfile))
            {
                DialogResult result = MessageBox.Show(null,
                    "文件已存在,将被重写!", "文件已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.Delete(_dbfile);
                SystemLog.I(TAG, "覆盖旧文件 " );
            }
            SQLiteConnection.CreateFile(_dbfile);
            SystemLog.I(TAG, "新建  " + _dbfile);
        }

        public void ExeSetKeyVal(Hashtable table)
        {
            foreach(string key in table.Keys){
                var value = table[key] as string;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    ExeSetKeyVal(key, value);
                    SystemLog.I(TAG, " 设置工程属性: " + key + ": " + value);
                }
            }
        }

        public void ExeSetKeyVal(string key, string value)
        {
            if (key == null || value == null)
            {
                return;
            }
            var count = ExeKeyNums(key);
            if (count == 0)
            {  // insert 1
                ExeInsertKeyValue(key, value);
            }
            else
            {
                UpdateKeyValue(key, value);
            }
        }

        private void UpdateKeyValue(string key, string value)
        {
            var sql = "update " + ProjectInfo.TYPE_TABLE_NAME_PROJECT + " set " + ProjectInfo.TYPE_COLUMN_VALUE
                     + "='" + value + " where key='" + key + "';";

            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
        }

        private void ExeInsertKeyValue(string key, string value)
        {
            var sql = "insert into " + ProjectInfo.TYPE_TABLE_NAME_PROJECT + "(" + ProjectInfo.TYPE_COLUMN_KEY + "," + ProjectInfo.TYPE_COLUMN_VALUE
                + ") values(" + "'" + key + "','" + value + "');";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
        }

        private int ExeKeyNums(string key)
        {
            if (key == null)
            {
                return 0;
            }
            var count = 0;
            var sql = "select count(" + ProjectInfo.TYPE_COLUMN_KEY + ") from " + ProjectInfo.TYPE_TABLE_NAME_PROJECT + " where " +
                ProjectInfo.TYPE_COLUMN_KEY + " = '" + key + "' ;";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            reader?.Close();
            return count;
        }

#if  USE_XML_CONFIG
        private void Init()
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
        XmlDocument _xmlDocument = new XmlDocument();

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

#endif
    }
}
