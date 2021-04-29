using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GIT_IGNORE;
using Newtonsoft.Json;

namespace MB_API
{
    internal static class Currency
    {
        internal static async Task ShowFirstCurrency(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(PASSWORDS.mbApiPath);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Above three lines can be replaced with new helper method below.
            // string responseBody = await client.GetStringAsync(uri);

            List<CurrencyModel> currencyList = JsonConvert.DeserializeObject<List<CurrencyModel>>(responseBody);

            Console.WriteLine($"Total currencies : {currencyList.Capacity}");

            Console.WriteLine(currencyList[0].ToString());
        }
    }

    internal class CurrencyModel
    {
        public int CurrencyCodeA { get; set; }
        public int CurrencyCodeB { get; set; }
        public long Date { get; set; }
        public float RateBuy { get; set; }
        public float RateSell { get; set; }
        public float RateCross { get; set; }

        // long unixEpoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

        public DateTime DateTimeFromUnix(long dateTime)
        {
            return new DateTime((dateTime * 10000000) + 621355968000000000);
        }

        public override string ToString()
        {
            return
                $"{CurrencyCodeA} => {CurrencyCodeB} : {RateBuy} / {RateSell} / {RateCross} [{DateTimeFromUnix(Date)}]";
        }
    }
}
