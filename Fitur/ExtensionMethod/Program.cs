using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            //string abjad = "abcdefghijklmnopqrstu";
            //Console.Write(abjad.LimitTextLength(1));

            //int? numVotes = "123".ToNullable<int>();
            //Console.Write(numVotes);
            //string thisWillNotThrowException = null;
            //int? nullsAreSafe = thisWillNotThrowException.ToNullable<int>();
            // Console.Write(thisWillNotThrowException);

            //string s = "(2+5)/3*(1*6)";
            //Console.Write(s.ValidateArithmeticExpression());

            //DateTime dt1 = new DateTime(2017, 08, 11);
            //DateTime dt2 = new DateTime(2017, 09, 19);
            //var monthTotalDiff = Time.GetTotalMonthDiff(dt1, dt2); //dt1.Time.GetMonthDiff(dt2);
            //Console.WriteLine(monthTotalDiff);

            //DateTime dt1 = new DateTime(2017, 08, 11);
            //DateTime dt2 = new DateTime(2017, 09, 19);
            //var monthTotalDiff = Time.GetMonthDiff(dt1, dt2); //dt1.Time.GetMonthDiff(dt2);
            //Console.WriteLine(monthTotalDiff);

            //var CallMethod = Requw.QueryString.GetValue("method", string.Empty);
            //var count = Request.QueryString.GetValue("count", 0);
            //var view_name = Request.Params.GetValue("view", string.Empty);
            //var entityID = Request.Params.GetValue<Guid>("UUID", Guid.Empty);
            //string result_string = "hello world!".ToFirstAll(true);
            //Console.WriteLine (result_string);

            string value = "abc";
            bool isnumeric = value.IsNumeric();// Will return false;
            value = "11";
            isnumeric = value.IsNumeric();// Will return true;

        }
    }


    #region Mara

    public static class Numerics
    {
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
    #endregion

    public static class Param
    {
        public static T GetValue<T>(this NameValueCollection collection, string key, T defaultValue)
        {
            if (collection != null && collection.Count > 0)
            {
                if (!string.IsNullOrEmpty(key) && collection[key] != null)
                {
                    var val = collection[key];

                    return (T)Convert.ChangeType(val, typeof(T));
                }
            }

            return (T)defaultValue;
        }
    }

    public static class Validator
    {
        static Regex ArithmeticExpression = new Regex(@"(?x)
                ^
                (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                (?>(?:
                    [-+*/]
                    (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                )*)
                (?(p)(?!))
                $
            ");

        public static bool ValidateArithmeticExpression(this string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return false;
            return ArithmeticExpression.IsMatch(expression);
        }
    }

    public static class Helper
    {
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source)
        {
            HashSet<T> itemsSeen = new HashSet<T>();
            HashSet<T> itemsYielded = new HashSet<T>();

            foreach (T item in source)
            {
                if (!itemsSeen.Add(item))
                {
                    if (itemsYielded.Add(item))
                    {
                        yield return item;
                    }
                }
            }
        }
    }

    public static class ToNullableStringExtension
    {
        public static T? ToNullable<T>(this string p_self) where T : struct
        {
            if (p_self != null)
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                if (converter.IsValid(p_self))
                {
                    return (T)converter.ConvertFromString(p_self);
                }
            }

            return null;
        }
    }

    public static class LimitText
    {
        public static string LimitTextLength(this string text, int maxLength, bool showEllipsis = true)
        {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException("maxLength", "Value must not be negative");
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            var n = text.Length;
            var ellipsis = showEllipsis ? "..." : string.Empty;
            var minLength = ellipsis.Length;
            maxLength = Math.Max(minLength, maxLength);
            return n > maxLength ? text.Substring(0, Math.Min(maxLength - minLength, n)) + ellipsis : text;
        }
    }

    public static class Time
    {
        public static string FormatIf<T>(this T value, string format) where T : struct
        {
            return FormatIf(value, null, format, null);
        }

        public static string FormatIf<T>(this T value, string format, string defaultText) where T : struct
        {
            return FormatIf(value, null, format, defaultText);
        }

        public static string FormatIf<T>(this T value, Func<T, bool> condition, string format, string defaultText) where T : struct
        {
            return (condition(value) ? string.Format(format, value) : defaultText);
        }

        public static int GetMonthDiff(this DateTime dt1, DateTime dt2)
        {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            return (l.Day == r.Day ? 0 : l.Day > r.Day ? 0 : 1)
              + (l.Month == r.Month ? 0 : r.Month - l.Month)
              + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        public static double GetTotalMonthDiff(this DateTime dt1, DateTime dt2)
        {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            var lDfM = DateTime.DaysInMonth(l.Year, l.Month);
            var rDfM = DateTime.DaysInMonth(r.Year, r.Month);

            var dayFixOne = l.Day == r.Day
              ? 0d
              : l.Day > r.Day
                ? r.Day * 1d / rDfM - l.Day * 1d / lDfM
                : (r.Day - l.Day) * 1d / rDfM;

            return dayFixOne
              + (l.Month == r.Month ? 0 : r.Month - l.Month)
              + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

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

        public static Decimal timeToDecimal(this string time)
        {
            int Hours = Convert.ToInt32(time.Split(':')[0]);
            decimal Minutes = Convert.ToInt32(time.Split(':')[1]);
            while (Minutes >= 60)
            {
                Minutes = Minutes % 60;
                Hours++;
            }
            //Minutes = Minutes/60;
            long test = Convert.ToInt32((Minutes / 60) / 10);
            return Hours + Minutes / 60;
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

        public static string ToFirstAll(this string input, bool switcher)
        {
            return new string(input.Split(' ').
                Select(n => switcher ? (n.ToArray().First().ToString().ToUpper() + n.Substring(1, n.Length - 1)) :
                    (n.ToArray().First().ToString().ToLower() + n.Substring(1, n.Length - 1))).
                    Aggregate((a, b) => a + ' ' + b).ToArray()).TrimEnd(' ');
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
