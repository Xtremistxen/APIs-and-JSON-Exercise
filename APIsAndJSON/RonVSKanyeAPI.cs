using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static void RonQuote()
        {
            var client = new HttpClient();
            
            var RonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = client.GetStringAsync(RonURL).Result;

            var ronQuote = JArray.Parse(ronResponse);

            Console.WriteLine($"Ron: {ronQuote[0]}\n");
        }

        public static void KanyeQuote()
        {
            var client = new HttpClient();
            
            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine($"Kanye: {kanyeQuote}\n");
        }
    }
}

