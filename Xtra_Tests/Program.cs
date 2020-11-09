using System;
using System.IO;

namespace Xtra_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Hello World!");
                
                var test = Path.GetFullPath(Environment.SpecialFolder.Desktop.ToString());

            System.Console.WriteLine(test);
        }
    }
}
