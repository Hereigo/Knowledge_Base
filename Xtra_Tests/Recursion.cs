namespace Xtra_Tests
{
    internal class Recursion
    {
        public static void Test()
        {
            System.Console.WriteLine(
                $"Factorial of 5 is {Factorial(5)} \r\n");

                            System.Console.WriteLine(
                $"Fibonachi of 5 is {Fibonachi(5)} \r\n");
        }

        static int Factorial(int x)
        {
            System.Console.WriteLine($"x = {x}");

            int rezult = x == 0
                        ? 1
                        : x * Factorial(x-1);

            System.Console.WriteLine(rezult);
            return rezult;                     
        }

        static int Fibonachi(int n)
        {
            System.Console.WriteLine($"n = {n}");

            int result = (n == 0 || n == 1)
                ? n
                : Fibonachi(n - 1) + Fibonachi(n - 2);
            
            System.Console.WriteLine($"n = 0/1/{n-1}+{n-2} - {result}");
            return result;     
        }
    }
}