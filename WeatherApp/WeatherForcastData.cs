using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WeatherApp
{
    class WeatherForcastData
    {
        public string m_City { get; set; }
        public float m_Tempreture { get; set; }
        public eTempratureUnits Unit { get; set;}
        public string m_WindSpeed { get; set; }
        public string m_Humidity { get; set; }
        public string m_Pressure { get; set; }

        public  WeatherForcastData(string i_City, float i_Temp, string i_WindSpeed)
        {
            this.m_City = i_City;
            this.m_Tempreture = i_Temp;
            this.m_WindSpeed = i_WindSpeed;
        }

        public static WeatherForcastData GetInstanceFromJson(string i_JsonStr)
        {
            JsonDocument jDoc = JsonDocument.Parse(i_JsonStr);
            JsonElement root = jDoc.RootElement;
            string cityName = root.GetProperty("name").ToString();
            JsonElement main = root.GetProperty("main");
            string temp = main.GetProperty("temp").ToString();
            string pressure = main.GetProperty("pressure").ToString();
            string humidity = main.GetProperty("humidity").ToString();
            JsonElement wind = root.GetProperty("wind");
            string windSpeed = wind.GetProperty("speed").ToString();

            return new WeatherForcastData("a", 1, "a");
        }

        public string getData()
        {
            return m_City + "|" + this.m_Tempreture + "|" + this.m_WindSpeed + "|" + this.m_Humidity + "|" + this.m_Pressure;
        }
    }
}
