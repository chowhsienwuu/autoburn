using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        SQLiteConnection m_dbConnection;
        void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
         //   m_dbConnection.
        }

        //在指定数据库中创建一个table
        void createTable()
        {
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //插入一些数据
        void fillTable()
        {
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            Program p = new Program();

            p.createNewDatabase();
            p.connectToDatabase();
            p.createTable();
            p.fillTable();
            p.printHighscores();


            //   Console.WriteLine("in main thread  begain " + Thread.CurrentThread.ManagedThreadId + DateTime.Now);

            Application.Run(new windowsform());
            //var path = @"D:\ZD3D";

            //DirectoryInfo folder = new DirectoryInfo(path);

            ////foreach (FileInfo file in folder.GetFiles("*.txt"))
            ////{
            ////    Console.WriteLine(file.FullName);
            ////}
            //var file = folder.EnumerateFiles();
            //var dir = folder.EnumerateDirectories();


            //Console.WriteLine("..");

            //XmlTextReader reader = new XmlTextReader(@"D:\books.xml");

            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element: // The node is an element.
            //            Console.Write("<" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //        case XmlNodeType.Text: //Display the text in each element.
            //            Console.WriteLine(reader.Value);
            //            Console.WriteLine("lanlan" + reader.Value + ".." + reader.Name + ".." + reader.AttributeCount);
            //            break;
            //        case XmlNodeType.EndElement: //Display the end of the element.
            //            Console.Write("</" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //    }
            //}
            //Console.ReadLine();

            //Program p = new Program();
            //p.print();
            //var strret = Task.Run(() => { p.q(); });


            //Console.WriteLine("in main thread " + Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now + strret.Result);
            //var t = p.ayncprint();
            //Console.WriteLine("in main thread 001");
            //Console.WriteLine("in main thread end" + Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now + t);
            //Console.ReadLine();
        }

        async Task<string> ayncprint()
        {
            Thread.Sleep(2000);
            Console.WriteLine("in ayncprint thread " + Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now);
            return "9";
        }

        string  print(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("in print thread " + Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now);
            return "i return " + s;
        }
        void q() { }
    }
}
