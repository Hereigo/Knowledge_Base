using System;

namespace Xtra_Tests
{
    class Program
    {
        public static DateTime GetGasDayFor(DateTime date)
        {
            return date >= new DateTime(date.Year, date.Month, date.Day, 6, 0, 0, 0)
                ? date.Date
                : date.AddDays(-1).Date;
        }

        public static void CalcGasDayFromNow()
        {
            var date = DateTime.Now;

            DateTime endDate;

            if (date.Hour >= 6)
            {
                endDate = date.AddDays(1).Date.AddHours(6);
            }
            else
            {
                endDate = date.Date.AddHours(6);
            }

            var hoursBetween = (int)date.Subtract(endDate).TotalHours + 24 + 1;

            Console.WriteLine("Current time : " + date);
            Console.WriteLine("End time : " + endDate);
            Console.WriteLine((int)date.Subtract(endDate).TotalHours);
            Console.WriteLine("Hours Between : " + hoursBetween);
        }

        static void Main(string[] args)
        {
            var cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

            DateTime cetDateTimeStart = TimeZoneInfo.ConvertTime(DateTime.Now.Date.AddHours(6), cetTimeZone);
            //TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.Date.AddHours(6), cetTimeZone);

            Console.WriteLine(cetDateTimeStart);
        }
    }
}

