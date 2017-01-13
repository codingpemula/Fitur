using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //string result = FormatString.Format(@"Hello @Name! Welcome to C#!", new { Name = "World" });
            //Console.Write(result);

            //string nonDate = "Foo";
            //string someDate = "Jan 1 2010";

            //bool isDate = nonDate.IsDate(); //false
            //isDate = someDate.IsDate(); //true
            //Console.WriteLine(isDate);

            //int weekNumber = DateTime.Now.WeekOfYearISO8601();
            //Console.WriteLine(weekNumber);

            //var str = "IsmaraAdiSaputra";
            //Console.WriteLine(str.SplitPascalCase());

            //int value = 15;
            //Console.WriteLine(value.IsBetween(14, 16));

            //var l = new List<Employee>();
            //var r = new Random();
            //for (int i = 0; i < 1000; i++)
            //{
            //    l.Add(new Employee { name = i.ToString(), salary = r.Next(1000) });
            //}

            //Console.WriteLine(l.FindMin(emp => emp.salary)?.name);
            // Console.WriteLine(l.FindMax(emp => emp.salary)?.name);

            //double number = 2.2365;

            //string display = number.DisplayDouble(4); // 2.24
            //Console.WriteLine(display);

            //int seconds = 78654;
            //// Returns a TimeSpan object with 21 Hours, 50 Minutes and 54 Seconds
            //TimeSpan ts = seconds.IntegerToTimeSpan();
            //Console.WriteLine(ts);

            //DateTime nows = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
            // Console.WriteLine(nows);

            //TimeSpan ts = new TimeSpan(1, 6, 4, 34);
            //string display = ts.TimeSpanToString(); // 30 hours 4 mins
            //Console.WriteLine(display);

            //int seconds = 3600;

            //string display = seconds.SecondsToString(); // 2 hours 11 mins
            //Console.WriteLine(display);
        }
    }
    
    public static class Time
    {
        public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek day)
        {
            var d = new GregorianCalendar().AddDays(dt, -((int)dt.DayOfWeek) + (int)day);
            return (d.Day < dt.Day) ? d.AddDays(7) : d;
        }

        public static string TimeSpanToString(this TimeSpan timeSpan)
        {
            var s = TimeSpan.FromSeconds(timeSpan.TotalSeconds);

            return string.Format("{0} hours {1} mins", (int)s.TotalHours, s.Minutes);
        }

        public static string SecondsToString(this int totalSeconds)
        {
            var s = TimeSpan.FromSeconds(totalSeconds);

            return string.Format("{0} hours {1} mins", (int)s.TotalHours, s.Minutes);
        }
    }

    public static class Number
    {
        public static string DisplayDouble(this double value, int precision)
        {
            return value.ToString("N" + precision);
        }

        public static TimeSpan IntegerToTimeSpan(this int totalSeconds)
        {
            return new TimeSpan(0, 0, totalSeconds);
        }
    }

    public static class FormatString
    {
        public static string Format(this string template, object data)
        {
            return Regex.Replace(template, @"@([\w\d]+)", match => GetValue(match, data));
        }

        public static string GetValue(Match match, object data)
        {
            var paraName = match.Groups[1].Value;
            try
            {
                var proper = data.GetType().GetProperty(paraName);
                return proper.GetValue(data).ToString();
            }
            catch (Exception)
            {
                var errMsg = string.Format("Not find'{0}'", paraName);
                throw new ArgumentException(errMsg);
            }
        }
    }

    public static class Convert
    {
        public static bool IsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return (DateTime.TryParse(input, out dt));
            }
            else
            {
                return false;
            }
        }
    }

    public static class Week
    {
        public static int WeekOfYearISO8601(this DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            return week;
        }
    }

    public static class SplitCase
    {
        public static string SplitPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }

    public static class BeetWeen
    {
        public static bool IsBetween(this int value, int start, int end)
        {
            return Comparer<int>.Default.Compare(value, start) >= 0 && Comparer<int>.Default.Compare(value, end) <= 0;
        }
    }

    static class Extensions
    {

        public static T FindMin<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
        where TValue : IComparable<TValue>
        {

            T result = list.FirstOrDefault();
            if (result != null)
            {
                var bestMin = predicate(result);
                foreach (var item in list.Skip(1))
                {
                    var v = predicate(item);
                    if (v.CompareTo(bestMin) < 0)
                    {
                        bestMin = v;
                        result = item;
                    }
                }
            }
            return result;
        }

        public static T FindMax<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
        where TValue : IComparable<TValue>
        {
            T result = list.FirstOrDefault();
            if (result != null)
            {
                var bestMax = predicate(result);
                foreach (var item in list.Skip(1))
                {
                    var v = predicate(item);
                    if (v.CompareTo(bestMax) > 0)
                    {
                        bestMax = v;
                        result = item;
                    }
                }
            }
            return result;
        }
    }

    public class Employee
    {
        public string id = "";
        public string name = "";
        public decimal salary = 0;   
    }

}
