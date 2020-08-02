using System;
using System.Collections.Generic;

namespace IO_SubDirectories
{
    internal static class Poligon
    {
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

        internal static void TestMe()
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
                //    var tempNum1 = item.Num1;
                //    item.Num1 = item.Num2;
                //    item.Num2 = tempNum1;

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
