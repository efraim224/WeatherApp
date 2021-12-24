using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = args[0];
            string request = WeatherRequestBuilder.GetRequest(city);
            RequestHandler requestHandler = new RequestHandler(request);
            string json = requestHandler.GetJsonAsStr();
            WeatherForcastData weather = WeatherForcastData.GetInstanceFromJson(json);
            Console.WriteLine(weather.getData());
            Console.ReadLine();

        }
    }
}
