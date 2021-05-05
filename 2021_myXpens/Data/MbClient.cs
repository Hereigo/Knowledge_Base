using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyXpens.Data
{
    public class MbClient
    {
        private readonly AppStaticValues _appValues;

        public MbClient(AppStaticValues appValues)
        {
            _appValues = appValues;
        }

        // TODO :
        // HttpClient is intended to be instantiated once per application, rather than per-use.

        private static readonly HttpClient client = new HttpClient();
        private AppStaticValues appValues;

        // TODO:
        // Call asynchronous network methods in a try/catch block to handle exceptions!

        // TODO:
        // Create Logs GB !!!

        public async Task<string> GetTestData(string test)
        {
            client.DefaultRequestHeaders.Add("X-Token", test);

            string responseBody = await client.GetStringAsync(_appValues.TestUri);

            var json = JsonSerializer.Deserialize<Test>(responseBody);

            Console.WriteLine(responseBody);




            return "__TEST!!!!!!!!!";
        }
    }

    internal class Test
    {

        // TODO :

    }
}
