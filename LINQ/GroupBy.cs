using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class GroupBy
    {
        public static void Run()
        {
            var fullDataList = A_Data.GetSomeList().ToList();
            fullDataList
                .AddRange(A_Data.GetPrioList().ToList());

            var grouppedList = fullDataList.GroupBy(l => l.Id);

            foreach (var group in grouppedList.OrderBy(i => i.Key))
            {
                Console.WriteLine($"Group {group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine($" -- {item.Name}");
                }
            }
        }
    }
}
