using System;
using System.Net.Http;
using System.Threading.Tasks;
using GIT_IGNORE;

namespace MB_API
{
    internal static class Personal
    {
        internal static async Task ClientInfo(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("X-Token", PASSWORDS.mbXToken);

            string responseBody = await client.GetStringAsync(PASSWORDS.mbUri);

            // System.IO.File.WriteAllText("aaa.txt", responseBody);

            Console.WriteLine(responseBody);
        }
    }
}