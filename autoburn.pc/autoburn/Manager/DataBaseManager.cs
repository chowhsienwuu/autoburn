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

            if (File.Exists(ProgramInfo.DBFILEFULLPATHFILE))
            {
                var connect = "Data Source=" + ProgramInfo.DBFILEFULLPATHFILE + "; Version=3;";
                _dbConnection = new SQLiteConnection(connect);
            }
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
        //void printHighscores()
        //{
        //    string sql = "select * from highscores order by score desc";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    SQLiteDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //        Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        //    Console.ReadLine();
        //}

    }

}
