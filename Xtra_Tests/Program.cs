using System;
using Humanizer;

namespace Xtra_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Humanize Quantities :");

            Console.WriteLine("case".ToQuantity(0)); // 0 cases
            Console.WriteLine("case".ToQuantity(1)); // 1 case
            Console.WriteLine("case".ToQuantity(5)); // 5 cases

            Console.WriteLine("Humanize Dates :");

            Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize()); // yesterday
            Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());  // 2 hours ago
            Console.WriteLine(TimeSpan.FromDays(1).Humanize());          // 1 day
            Console.WriteLine(TimeSpan.FromDays(16).Humanize());         // 2 weeks
        }
    }
}
