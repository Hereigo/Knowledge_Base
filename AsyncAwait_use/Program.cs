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

            Console.WriteLine(rez.Result);
            Console.WriteLine("Done.");
            Console.Read();
        }

        private static async Task<int> AsyncMethodsChain()
        {
            var test = await Task.Run(MethOne);

            return await Task.Run(() => MethTwo(test));
        }

        private static int MethOne()
        {
            Thread.Sleep(3000);
            return 100;
        }

        static int MethTwo(int x)
        {
            Thread.Sleep(3000);
            return x * 2;
        }
    }
}
