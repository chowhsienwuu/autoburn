using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
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
