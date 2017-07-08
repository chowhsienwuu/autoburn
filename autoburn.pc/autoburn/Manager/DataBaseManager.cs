using Autoburn.util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class DataBaseManager
    {
        public const string TAG = "DataBaseManager";
        private DeviceManager _DeviceManager = null;

        private SQLiteConnection _dbConnection;
        public DataBaseManager(DeviceManager manager)
        {
            _DeviceManager = manager;

            if (File.Exists(ProgramInfo.DBFILE))
            {
                var connect = "Data Source=" + ProgramInfo.DBFILE + "; Version=3;";
                _dbConnection = new SQLiteConnection(connect);
                _dbConnection.Open();
                SystemLog.I(TAG, " database " + ProgramInfo.DBFILE + ".opened");
            }
            else
            {
                SystemLog.E(TAG, " database " + ProgramInfo.DBFILE + ".not found");
            }
         //  test();         
        }

        public SQLiteDataReader ExeGetReader(string sqlstring)
        {
            if (_dbConnection == null || sqlstring == null)
            {
                return null;
            }
            var sql = sqlstring + ";";

            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            return command.ExecuteReader();
        }

        public string GetConfigValue(string key)
        {
            var value = "";
            var sql = "select value from " + ConfigInfo.TYPE_TABLENAME + " where " + ConfigInfo.TYPE_COLUMN_KEY + 
               " = '" + key + "';" ;
            var read = ExeGetReader(sql);

            while (read.Read())
            {
                try
                {
                    NameValueCollection nv = read.GetValues();
                    value = nv.Get(ConfigInfo.TYPE_COLUMN_VALUE);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(" excepiton " + e.ToString());
                }
            }

            read.Close();
            return value;
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
            var sql = "update " + ConfigInfo.TYPE_TABLENAME + " set " + ConfigInfo.TYPE_COLUMN_VALUE
                     + "='" + value + "', time=datetime('now','localtime') where key='" + key + "';";

            using (SQLiteCommand command = new SQLiteCommand(sql, _dbConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void ExeInsertKeyValue(string key, string value)
        {
            var sql = "insert into " + ConfigInfo.TYPE_TABLENAME + "(" + ConfigInfo.TYPE_COLUMN_KEY + "," + ConfigInfo.TYPE_COLUMN_VALUE
                + "," + ConfigInfo.TYPE_COLUMN_TIME + ") values(" + "'" + key + "','" + value + "', datetime('now', 'localtime'));";
            using (SQLiteCommand command = new SQLiteCommand(sql, _dbConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private int ExeKeyNums(string key)
        {
            if (key == null)
            {
                return 0;
            }
            var count = 0;
            var sql = "select count(" + ConfigInfo.TYPE_COLUMN_KEY + ") from " + ConfigInfo.TYPE_TABLENAME + " where " +
                ConfigInfo.TYPE_COLUMN_KEY + " = '" + key + "' ;";

            using (SQLiteCommand command = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader?.Close();
                }
            }
            return count;
        }

        ////插入一些数据
        //void fillTable()
        //{
        //    string sql = "insert into highscores (name, score) values ('Me', 3000)";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();

        //    sql = "insert into highscores (name, score) values ('Myself', 6000)";
        //    command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();

        //    sql = "insert into highscores (name, score) values ('And I', 9001)";
        //    command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();
        //}

        ////使用sql查询语句，并显示结果
        #region test
        private void printHighscores()
        {
            if (_dbConnection == null)
            {
                return;
            }

            string sql = "select * from " + ChipInfo.TYPE_TABLE_NAME_CHIPINFO + ";";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.Out.WriteLine("--" + reader.HasRows);
            while (reader.Read())
            {
                Console.WriteLine(" test read:  " + reader["vendor"]);
            }
            reader.Close(); 
           // Console.ReadLine();
        }
        private void test()
        {
            printHighscores();
            printHighscores();
            //  throw new NotImplementedException();
            //ExeSetKeyVal("9999999", "666");
            //ExeSetKeyVal("999xxx", "666");
            // ExeSetKeyVal("lao", "updatexx");
        }
        #endregion
    }
}
