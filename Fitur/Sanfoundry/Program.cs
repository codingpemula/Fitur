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
            Console.WriteLine(b.IsEvenOrOdd(1));
        }
    }


    public class Basic
    {

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
            number2 =  temp;


            Console.WriteLine(number1);
            Console.WriteLine(number2);

        }
    }



}
