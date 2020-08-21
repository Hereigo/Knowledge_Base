using System;
using System.Collections.Generic;
using System.Linq;

namespace IO_SubDirectories
{
    internal static class Poligon
    {
        internal static void TEST_RUN()
        {
            List<Tuple<int, int, int>> testList = new List<Tuple<int, int, int>>();

            testList.Add(Tuple.Create(1, 2, 3));
            testList.Add(Tuple.Create(4, 5, 6));
            testList.Add(Tuple.Create(7, 8, 9));

            var Test = testList.FirstOrDefault(t => t.Item1 == 3);

            Console.WriteLine(Test?.Item3);
        }


        private class TestClass
        {
            public int ID { get; set; }
            public int Num1 { get; set; }
            public int Num2 { get; set; }

            public override string ToString()
            {
                return ID + " - " + Num1 + " - " + Num2;
            }
        }

        internal static void CompareSpeed()
        {
            DateTime beginTime = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                var tests = new List<TestClass>()
                {
                    new TestClass(){ ID=1, Num1=100, Num2=111 },
                    new TestClass(){ ID=2, Num1=200, Num2=222 },
                    new TestClass(){ ID=3, Num1=300, Num2=333 }
                };

                var rezult = new List<TestClass>();

                foreach (var item in tests)
                {
                    // var tempNum1 = item.Num1;
                    // item.Num1 = item.Num2;
                    // item.Num2 = tempNum1;

                    rezult.Add(new TestClass() { ID = item.ID, Num1 = item.Num2, Num2 = item.Num1 });
                }

                foreach (var item in rezult)
                {
                    Console.WriteLine(item);
                }
            }

            DateTime currentTime = DateTime.Now;
            long elapsedTicks = currentTime.Ticks - beginTime.Ticks;
            Console.WriteLine("\r\n {0:N0} nanoseconds spend.", elapsedTicks * 100);
        }
    }
}
