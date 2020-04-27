using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_46
{
    class MergeCollections
    {
        public class Data
        {
            public int Id { get; set; }
            public bool IsPriority { get; set; }
            public string Name { get; set; }
        }

        static void Test()
        {
            var listSome = new List<Data>()
            {
                new Data { Id=2, IsPriority=false, Name="some2"},
                new Data { Id=3, IsPriority=false, Name="some3"},
                new Data { Id=4, IsPriority=false, Name="some4"},
                new Data { Id=5, IsPriority=false, Name="some5"},
            };

            var listPrio = new List<Data>()
            {
                new Data { Id=1, IsPriority=true, Name="prio1"},
                new Data { Id=2, IsPriority=true, Name="prio2"},
                new Data { Id=4, IsPriority=true, Name="prio4"},
                new Data { Id=6, IsPriority=true, Name="prio5"},
            };

            // Data[] rezult = new Data[];

            foreach (var item in listSome)
            {
                if (!listPrio.Any(x => x.Id == item.Id))
                {
                    listPrio.Add(item);
                }
            }

            //var rezult = list1.Where(x => x.Id != 2);



            //    List<Data> rezult = MergeByPrio(list1, list2);

            foreach (var item in listPrio)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }

            //}

            //private static List<Data> MergeByPrio(List<Data> list1, List<Data> list2)
            //{

            //    var test = list2.Where(x => x.Id == )


            //    List<Data> result = list2.Select(p => p).Concat(list2.Any(x => x.Id == p.Id))


            //        return result;
        }
    }
}
