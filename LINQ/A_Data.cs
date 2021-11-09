using System.Collections.Generic;

namespace LINQ
{
    public class A_Data
    {
        public int Id { get; set; }
        public bool IsPriority { get; set; }
        public string Name { get; set; }

        public static IEnumerable<A_Data> GetSomeList()
        {
            return new List<A_Data>()
            {
                new A_Data { Id = 2, IsPriority = false, Name = "some2" },
                new A_Data { Id = 3, IsPriority = false, Name = "some3" },
                new A_Data { Id = 4, IsPriority = false, Name = "some4" },
                new A_Data { Id = 5, IsPriority = false, Name = "some5" }
            };
        }

        public static IEnumerable<A_Data> GetPrioList()
        {
            return new List<A_Data>()
            {
                new A_Data { Id = 1, IsPriority = true, Name = "prio1" },
                new A_Data { Id = 2, IsPriority = true, Name = "prio2" },
                new A_Data { Id = 4, IsPriority = true, Name = "prio4" },
                new A_Data { Id = 6, IsPriority = true, Name = "prio5" },
            };
        }
    }
}
