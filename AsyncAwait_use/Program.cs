using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait_use
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Async started.");
            Task<int> rez = AsyncMethodsChain();
            Console.WriteLine("Method Main is waiting for result...");
            Console.WriteLine(rez.Result);
            Console.WriteLine("Done.");
            Console.Read();
        }

        private static async Task<int> AsyncMethodsChain()
        {
            Console.WriteLine("AsyncMethodsChain started.");
            var test = await Task.Run(MethOne);
            var result = await Task.Run(() => MethTwo(test));
            Console.WriteLine("AsyncMethodsChain finished.");
            return result;
        }

        private static int MethOne()
        {
            Console.WriteLine("Method_1 started.");
            Thread.Sleep(3000);
            Console.WriteLine("Method_1 finished.");
            return 100;
        }

        static int MethTwo(int x)
        {
            Console.WriteLine("Method_2 finished.");
            Thread.Sleep(3000);
            Console.WriteLine("Method_2 finished.");
            return x * 2;
        }
    }
}
// Async started.
// AsyncMethodsChain started.
// Method_1 started.
// Method Main is waiting for result...
// ...
// Method_1 finished.
// Method_2 finished.
// ...
// Method_2 finished.
// AsyncMethodsChain finished.
// 200
// Done.