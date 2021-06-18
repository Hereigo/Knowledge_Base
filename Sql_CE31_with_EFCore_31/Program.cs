using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sql_CE31_EFCore_FromCoreTemplate
{
    class Program
    {
        const string sqlCeConnectionString = @"Data Source=C:\intel\terminal.sdf";

        static void Main()
        {
            try
            {
                Console.WriteLine("Started");

                var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

                var options = optionsBuilder
                    .UseSqlCe(sqlCeConnectionString)
                    .Options;

                var context = new MyContext(options);

                Console.WriteLine($"Barcodes : {context.Barcodes.Count()}");
                Console.WriteLine($"LastSync : {context.LastSync.Count()}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
