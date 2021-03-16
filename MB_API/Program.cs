using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB_API
{
    internal static class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use.

        private static readonly HttpClient client = new HttpClient();

        private static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                // await Currency.ShowFirstCurrency(client);

                await Personal.ClientInfo(client);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
