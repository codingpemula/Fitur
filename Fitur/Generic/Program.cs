using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Compare.IsEqual(1, "1") ? "Equal" : "Not Equal";
            Console.WriteLine(value);

            //generic method solution
            string genericValue = Compare.IsEqual<string>("1", "1") ? "Equal" : "Not Equal";
            Console.WriteLine("Generic Method string " + genericValue);

            string genericValue2 = Compare.IsEqual<int>(1, 2) ? "Equal" : "Not Equal";
            Console.WriteLine("Generic Method int " + genericValue2);
        }
    }

    public static class Utils
    {
        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }

    public static class Compare
    {
        public static bool IsEqual(string x, string y)
        {
            return x.Equals(y);
        }

        public static bool IsEqual(int x, int y)
        {
            return x.Equals(y);
        }

        public static bool IsEqual(object x, object y)
        {
            return x.Equals(y);
        }

        //This is Generic Metode
        public static bool IsEqual<T>(T x, T y)
        {
            return x.Equals(y);
        }
    }
    //This Generic Class
    public static class ComparisonUtils<T>
    {
        public static bool IsEqual(T x, T y)
        {
            return x.Equals(y);
        }

        public static bool NotEqual(T x, T y)
        {
            return !x.Equals(y);
        }
    }

    class Snack
    {
        public string snack_id { get; set; }
        public string snack_name { get; set; }
        public double snack_price { get; set; }
    }

    class Beverage
    {
        public string beverage_id { get; set; }
        public string beverage_name { get; set; }
        public double beverage_price { get; set; }
    }

    class ItemsStore
    {
        public static List<Snack> GetSnacks()
        {
            var snack = new List<Snack>()
            {
                new Snack { snack_id = "1", snack_name = "Piza", snack_price = 120 },
                new Snack { snack_id = "2", snack_name = "Jello", snack_price = 20 }
            };

            return snack;
        }

        public static List<Beverage> GetBeverages()
        {
            var beverage = new List<Beverage>()
            {
                new Beverage {beverage_id="1",beverage_name="Coke",beverage_price=15},
                new Beverage {beverage_id="2",beverage_name="Milkshake laced with 1% Gin and 0.5% Vodka",beverage_price = 20}
            };

            return beverage;
        }
    }
}
