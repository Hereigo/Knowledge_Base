using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_46
{
    public static class MergeCollectionsByPrio
    {
        public static void Run()
        {
            List<A_Data> listSomeData = A_Data.GetSomeList().ToList();
            List<A_Data> listPrioData = A_Data.GetPrioList().ToList();

            Console.WriteLine("Some Collection ;");
            foreach (var item in listSomeData.OrderBy(i => i.Id))
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }

            Console.WriteLine("Priority Collection :");
            foreach (var item in listPrioData.OrderBy(i => i.Id))
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }

            // Merging by Priority :
            foreach (var some in listSomeData)
            {
                if (!listPrioData.Any(p => p.Id == some.Id))
                {
                    listPrioData.Add(some);
                }
            }

            Console.WriteLine("Merged Collection :");
            foreach (var item in listPrioData.OrderBy(i => i.Id))
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }
    }
}
