using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqBasic.Linq1();
            LinqBasic.WithoutLinq1();
        }
    }


    public static class LinqBasic
    {
        //Use Linq
        public static void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from n in numbers
                where n < 5
                select n;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        public static void WithoutLinq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            foreach (var item in numbers)
            {
                if (item < 5)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }


}
