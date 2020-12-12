using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Tg_test{

    public class CurrencyService
    {
        private string get(string url)
        {
            string rt;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return rt;
        }

        internal string getResult(){
            var res = get("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            var data = JArray.Parse(res);
            var usd = (string)data[20]["rate"];
            var rub = (string)data[18]["rate"];
            var euro = (string)data[33]["rate"];
            return $"{usd} UAH = 1$\n{rub} UAH = 1₽\n{euro} UAH = 1€";
        }
    }
}