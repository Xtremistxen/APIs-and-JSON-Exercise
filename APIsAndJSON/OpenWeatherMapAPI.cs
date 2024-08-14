using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static void Weather()
        {

            // This will grab the key from appsettings and apply key
            var appsettingsText = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(appsettingsText).GetValue("key").ToString();

            //This will allow the user to enter a zipcode
            Console.WriteLine("Please enter a zipcode:");
            var zip = Console.ReadLine();

            //This is the url
            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid{apiKey}&units=imperial";
            var client = new HttpClient();
            
            //This will give us the result
            var jsonText = client.GetStringAsync(url).Result;
            var weatherObject = JObject.Parse(jsonText);
            Console.WriteLine($"The current temperature is {weatherObject["main"]["temp"]}F.");
        }
    }
}
