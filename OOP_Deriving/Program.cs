using System;

namespace OOP_Deriving
{
    internal static class Program
    {
        private static void Main()
        {
            StringOverride stringOverride = new StringOverride("Default name.");

            Console.WriteLine(stringOverride.ToString());

            Console.WriteLine("==============================");

            Use_Base.Test();

            Console.WriteLine("\n Done.");
            Console.ReadKey();
        }
    }
}
