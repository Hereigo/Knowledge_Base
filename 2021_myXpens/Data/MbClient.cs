using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyXpens.Data
{
    public class MbClient
    {
        // TODO :
        // HttpClient is intended to be instantiated once per application, rather than per-use.

        private static readonly HttpClient client = new();

        private readonly AppStaticValues _appValues;

        public MbClient(AppStaticValues appValues)
        {
            _appValues = appValues;
        }

        // TODO:
        // Call asynchronous network methods in a try/catch block to handle exceptions!

        // TODO:
        // Create Logs DB !!!
        // Create Logs DB !!!
        // Create Logs DB !!!

        public async Task<decimal> GetTestData(string test)
        {
            var number = -1m;
            client.DefaultRequestHeaders.Add(_appValues.HeaderParam, test);
            string responseBody = await client.GetStringAsync(_appValues.TestUri);
            using (JsonDocument jDoc = JsonDocument.Parse(responseBody))
            {
                JsonElement aaa = jDoc.RootElement.GetProperty(_appValues.PropertyA);
                aaa[0].GetProperty(_appValues.PropertyB).TryGetDecimal(out decimal bbb);
                aaa[0].GetProperty(_appValues.PropertyC).TryGetDecimal(out decimal ccc);
                number = Math.Round((bbb - ccc) / 100);
            }
            return number;
        }
    }
}
