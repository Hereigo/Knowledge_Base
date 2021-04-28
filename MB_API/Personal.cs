using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB_API
{
    internal static class Personal
    {
        internal static async Task ClientInfo(HttpClient client)
        {
            string uri = "https://api.monobank.ua/personal/client-info";

            client.DefaultRequestHeaders.Add("X-Token", GIT_IGNORE.PASSWORDS.XToken);

            string responseBody = await client.GetStringAsync(uri);

            // File.WriteAllText("aaa.txt", responseBody);

            Console.WriteLine(responseBody);
        }
    }
}