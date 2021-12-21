using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "London";
            string request = WeatherRequestBuilder.GetRequest(city);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(request);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                HttpContent content = response.Content;
                WeatherForcastData.GetInstanceFromJson(content.ToString());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        /*static async Task<WeatherForcastData> GetProductAsync(string path)
        {
            WeatherForcastData product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.To;
            }
            return product;
        }*/
        }
}
