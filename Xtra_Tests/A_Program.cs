using System;

namespace Xtra_Tests
{
    internal static class A_Program
    {
        private static void Main()
        {
            // HumaniserUse.Test();
            // Override_Inheritance.Test();
            // Delegates_Basic.Test();
            // Recursion.Test();

            var pmbd = new PrivateMethodByDelegate();
            pmbd.Test();

            Console.ReadKey();
        }
    }
}
