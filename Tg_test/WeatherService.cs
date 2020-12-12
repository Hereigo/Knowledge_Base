using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Tg_test
{
    public class WeatherService
    {
        private static readonly string owmApiKey = "hsjafgjhasgfjh";

        private string FormatResult(string result)
        {
            var data = JObject.Parse(result);
            string Weather = (string)data["weather"][0]["main"];
            string Temp = (string)data["main"]["temp"];
            string FeelsLike = (string)data["main"]["feels_like"];
            return $"Weather: {Weather}\nTemp: {Temp}\nFeels like: {FeelsLike}";
        }

        internal string get(string cityName)
        {
            string url =
                $"http://api.openweathermap.org/data/2.5/weather?q={cityName},%20UA&type=like&units=metric&appid={owmApiKey}";

            string rt;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return FormatResult(rt);
        }
    }
}