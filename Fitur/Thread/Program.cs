using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);          // Kick off a new thread
            t.Start();                               // running WriteY()

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
}
