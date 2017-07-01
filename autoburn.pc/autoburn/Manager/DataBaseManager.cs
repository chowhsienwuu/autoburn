using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class DataBaseManager
    {
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
            }
          //  test();         
        }

        private void test()
        {
            printHighscores();
          //  throw new NotImplementedException();
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
        void printHighscores()
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
                Console.WriteLine("read:  " + reader["vendor"]);
            }

            reader.Close(); 
           // Console.ReadLine();
        }

    }

}
