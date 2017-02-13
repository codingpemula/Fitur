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
            b.PullMoneyInATM();
        }
    }

    #region Basic
    public class Basic
    {
        public void PullMoneyInATM()
        {
            int amount = 1000, deposit, withdraw;
            Console.Write("Enter You PIN = ");
            int pin = 0;
            int choice = 0;
            pin = int.Parse(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("Welcome ATM Service");
                Console.WriteLine("1. Check Balance\n");
                Console.WriteLine("2. Withdraw Cash\n");
                Console.WriteLine("3. Deposit Cash\n");
                Console.WriteLine("4. Quit\n");
                Console.WriteLine("*********************************************\n\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n YOUR BALANCE IN Rs : {0} ", amount);
                        break;
                    case 2:
                        Console.WriteLine("\n ENTER THE AMOUNT TO WITHDRAW: ");
                        withdraw = int.Parse(Console.ReadLine());
                        if (withdraw % 100 != 0)
                        {
                            Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN MULTIPLES OF 100");
                        }
                        else if (withdraw > (amount - 500))
                        {
                            Console.WriteLine("\n INSUFFICENT BALANCE");
                        }
                        else
                        {
                            amount = amount - withdraw;
                            Console.WriteLine("\n\n PLEASE COLLECT CASH");
                            Console.WriteLine("\n YOUR CURRENT BALANCE IS {0}", amount);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n ENTER THE AMOUNT TO DEPOSIT");
                        deposit = int.Parse(Console.ReadLine());
                        amount = amount + deposit;
                        Console.WriteLine("YOUR BALANCE IS {0}", amount);
                        break;
                    case 4:
                        Console.WriteLine("\n THANK U USING ATM");
                        break;
                }
            }
            Console.WriteLine("\n\n THANKS FOR USING OUT ATM SERVICE");
        }

        public void CountEnterNumber()
        {
            Console.Write("Enter The  Number : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The  Limit {0}", number);

            int count = 0;
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
