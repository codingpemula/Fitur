using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanfoundry
{
    class Program
    {
        static void Main(string[] args)
        {
            Basic b = new Basic();
            b.CountEnterNumber();
        }
    }

    #region Basic
    public class Basic
    {

        public void CountEnterNumber()
        {
            Console.Write("Enter The  Number : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The  Limit {0}", number);

            int count =0;
            int[] temp = new int[number];

            for (int i = 0; i < number; i++)
            {
                temp[i] = int.Parse(Console.ReadLine());
            }

            foreach (var item in temp)
            {
                if (item == 1)
                    count++;

            }
            Console.WriteLine("Number of 1's in the Entered Number : ");
            Console.WriteLine(count);
        }

        public string IsEvenOrOdd(int number)
        {
            if (number % 2 == 0)
                return "Even";
            else
                return "Odd";
        }

        public void Swap(int number1, int number2)
        {
            Console.WriteLine("Enter The First Number");
            number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Second Number");
            number2 = int.Parse(Console.ReadLine());

            Console.WriteLine(number1);
            Console.WriteLine(number2);

            int temp = number1;
            number1 = number2;
            number2 = temp;


            Console.WriteLine(number1);
            Console.WriteLine(number2);

        }
    }

    #endregion

}
