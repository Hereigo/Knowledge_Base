using System;

namespace RawSqlCommandsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var generator = new RawSqlGenerator();

                var order = new Order
                {
                    OrderId = 1,
                    ProductId = 2,
                    ProductName = "asdvf",
                    ProductPrice = 1000
                };

                var rezult = generator.InsertIntoTableNameByEntity<Order>(order);

                Console.WriteLine(rezult);

                Console.WriteLine("\r\n\r\ndone.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}
