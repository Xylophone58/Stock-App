using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockMarketApp
{
    class Program
    {
        private static readonly string apiKey = "W4BHR3LXFOU5MRB5";
        private static readonly string baseUrl = "https://www.alphavantage.co/query";

        static async Task Main(string[] args)
        {
            string symbol = "GME"; // Replace with your stock symbol
            await GetStockData(symbol);
        }

        private static async Task GetStockData(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=1min&apikey={apiKey}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Error fetching data");
                }
            }
        }
    }
}
