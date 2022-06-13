using System;

namespace CS_EXAMPLES
{
    internal static class A_Program
    {
        private static void Main()
        {
            // DoToKin.Test("https://..../");

            // Yield_Measure.Test(); // MUST BE RUN IN RELEASE-MODE!

            SlnCleaner.Test();

            // TCP_Client.Test();

            // HumaniserUse.Test();

            Override_Inheritance.Test();

            // Delegates_Basic.Test();

            // Recursion.Test();

            // var pmbd = new PrivateMethodByDelegate();
            // pmbd.Test();

            FileRenamer.Test();

            Console.ReadKey();
        }
    }
}
