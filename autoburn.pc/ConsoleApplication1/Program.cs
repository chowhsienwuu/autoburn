using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("in main thread  begain " + Thread.CurrentThread.ManagedThreadId + DateTime.Now);

            Program p = new Program();
            //  p.print();
            var strret = Task.Run(() => {p.q(); });


            //Console.WriteLine("in main thread " + Thread.CurrentThread.ManagedThreadId +" " + DateTime.Now  + strret.Result);
            var t = p.ayncprint();
            Console.WriteLine("in main thread 001");
            Console.WriteLine("in main thread end" + Thread.CurrentThread.ManagedThreadId + " " + DateTime.Now + t);
            Console.ReadLine();
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
