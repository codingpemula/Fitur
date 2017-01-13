using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static bool done;    // Static fields are shared between all threads
        static readonly object locker = new object();

        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();

            //ThreadStart job = new ThreadStart(ThreadJob);
            //Thread thread = new Thread(job);
            //thread.Start();

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Main thread: {0}", i);
            //    Thread.Sleep(1000);
            //}
        }

        static void Go()
        {
            lock (locker)
            {
                if (done ==  false)
                {
                    Console.WriteLine("Done");
                    done = true;
                }
            }
        }

        //static void Go()
        //{
        //    if (!done)
        //    {
        //        done = true;
        //        Console.WriteLine("Done");
        //    }
        //}

        static void ThreadJob()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other thread: {0}", i);
                Thread.Sleep(500);
            }
        }
    }
}
