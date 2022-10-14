using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quote = new QuoteGenerator(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye: {quote.Kanye()}");
                Console.WriteLine($"Ron Swanson: {quote.RonSwanson()}");

            }

            string key = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            Console.WriteLine("Enter a city: ");
            var city = Console.ReadLine();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?q=%7Bcity%7D&units=imperial&appid=%7BAPIKey%7D";
            Console.WriteLine();

            Console.WriteLine($"It is currently {OpenWeatherMapAPI.GetTemp(apiCall)} degrees F in this city.");

        }

    }
}