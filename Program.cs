using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string BASE_API_URL = "https://open.er-api.com/v6/latest/";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Currency Exchange Rate Checker");
        
        while (true)
        {
            Console.Write("\nEnter the base currency code (e.g., USD, EUR, GBP) or 'exit' to quit: ");
            string baseCurrency = Console.ReadLine().ToUpper();

            if (baseCurrency == "EXIT")
                break;

            try
            {
                await FetchExchangeRates(baseCurrency);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static async Task FetchExchangeRates(string baseCurrency)
    {
        try
        {
            // Fetch exchange rates
            HttpResponseMessage response = await client.GetAsync(BASE_API_URL + baseCurrency);
            response.EnsureSuccessStatusCode();
            
            // Read response as string
            string responseBody = await response.Content.ReadAsStringAsync();
            
            // Parse JSON
            JObject exchangeData = JObject.Parse(responseBody);
            
            // Check if rates are available
            if (exchangeData["result"]?.ToString() == "success")
            {
                Console.WriteLine($"\nExchange Rates for {baseCurrency}:");
                
                // Display top currencies
                string[] topCurrencies = { "USD", "EUR", "GBP", "JPY", "CAD", "AUD", "CHF", "CNY" };
                
                foreach (string currency in topCurrencies)
                {
                    if (currency != baseCurrency)
                    {
                        decimal rate = exchangeData["rates"][currency].Value<decimal>();
                        Console.WriteLine($"1 {baseCurrency} = {rate:F4} {currency}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not fetch exchange rates.");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Network error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error processing exchange rates: {e.Message}");
        }
    }
}