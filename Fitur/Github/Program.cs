using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] elements = new int[] { -5, 8, 22, 251, -158, 73 };
            //long sum = SumArrayElement.GetSumArray(elements);
            //Console.WriteLine(" {0} {1}", string.Join(", ", elements), sum);

            //ulong N = 4;
            //BellNumbers.Stirling(N);
            //Console.WriteLine("Bell({0}) = {1}", N, BellNumbers.Bell(N));
            SumArrayElement.Factorial2();

            Console.ReadLine();
        }
    }


    public class BellNumbers
    {
        private const int MaxN = 100;
        private const ulong N = 10;
        private static ulong[] m = new ulong[MaxN + 1];


        public static void Stirling(ulong n)
        {
            if (n == 0)
                m[0] = 1;
            else
                m[0] = 0;

            for (ulong i = 1; i <= n; i++)
            {
                m[i] = 1;
                for (ulong j = i - 1; j >= 1; j--)
                {
                    m[j] = (j * m[j]) + m[j - 1];
                }
            }
        }

        public static ulong Bell(ulong n)
        {
            ulong result = 0;
            for (ulong i = 0; i <= n; i++)
            {
                result += m[i];
            }
            return result;
        }

    }


    public class SumArrayElement
    {

        public static long GetSumArray(int[] elements)
        {
            long sum = 0L;
            for (int i = 0; i < elements.Length; i++)
            {
                sum += elements[i];
            }
            return sum;
        }

        public static void Factorial()
        {
            Console.Write("Enter Number Factorial : ");
            int number = int.Parse(Console.ReadLine());
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i);
                if (i != number)
                    Console.Write("*");
                if (i == number)
                    Console.Write("=");
                result = result * i;
            }
            Console.Write(result);
        }


        public static void Factorial2()
        {
            Console.Write("Enter Number Factorial : ");
            int number = int.Parse(Console.ReadLine());
            int result = 1;
            for (int i = number; i <= number && i > 0; i--)
            {
                Console.Write(i + "*");
                if (i == 1)
                    Console.Write("=");
                result = result * i;
            }
            Console.Write(result);
        }

    }
}
