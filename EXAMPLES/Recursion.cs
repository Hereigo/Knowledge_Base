using System;

namespace EXAMPLES
{
    internal static class Recursion
    {
        public static void Test()
        {
            Console.WriteLine($"\r\nFactorial of 5 is {Factorial(5)} \r\n");
            Console.WriteLine($"\r\nFibonacci of 5 is {Fibonacci(5)} \r\n");
        }

        // Factorial number of N = 1 * 2 * 3 * ... * N.

        private static int Factorial(int x)
        {
            Console.WriteLine($"x = {x}");

            int rezult = x == 0
                        ? 1
                        : x * Factorial(x - 1);

            Console.WriteLine(rezult);
            return rezult;
        }

        // Fibonacci numbers : 0, 1, 1, 2, 3, 5, 8, 13, ...

        private static int Fibonacci(int n)
        {
            Console.WriteLine($"inp = {n}");

            int result = n == 0 || n == 1
                ? n
                : Fibonacci(n - 1) + Fibonacci(n - 2);

            Console.WriteLine($"out = {result} >>");

            return result;
        }
        // inp = 5
        // inp = 4
        // inp = 3
        // inp = 2
        // inp = 1
        // out = 1 >>
        // inp = 0
        // out = 0 >>
        // out = 1 >>
        // inp = 1
        // out = 1 >>
        // out = 2 >>
        // inp = 2
        // inp = 1
        // out = 1 >>
        // inp = 0
        // out = 0 >>
        // out = 1 >>
        // out = 3 >>
        // inp = 3
        // inp = 2
        // inp = 1
        // out = 1 >>
        // inp = 0
        // out = 0 >>
        // out = 1 >>
        // inp = 1
        // out = 1 >>
        // out = 2 >>
        // out = 5 >>
    }
}