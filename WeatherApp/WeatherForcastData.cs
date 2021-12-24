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
        public eTempratureUnits m_Unit { get; set;}
        public float m_WindSpeed { get; set; }
        public float m_Humidity { get; set; }
        public float m_Pressure { get; set; }

        public  WeatherForcastData(string i_City, float i_Temp, float i_WindSpeed, float i_Humidity, float i_Pressure)
        {
            this.m_City = i_City;
            this.m_Tempreture = i_Temp;
            this.m_WindSpeed = i_WindSpeed;
            this.m_Humidity = i_Humidity;
            this.m_Pressure = i_Pressure;
        }

        public WeatherForcastData(string i_City, float i_Temp, float i_WindSpeed, float i_Humidity, float i_Pressure, eTempratureUnits i_Units)
        {
            this.m_City = i_City;
            this.m_Tempreture = i_Temp;
            this.m_WindSpeed = i_WindSpeed;
            this.m_Humidity = i_Humidity;
            this.m_Pressure = i_Pressure;
            this.m_Unit = i_Units;
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

            return parseFromStr(cityName, temp, windSpeed, humidity, pressure);
        }

        private static WeatherForcastData parseFromStr(string i_City, string i_Temp, string i_WindSpeed, string i_Humidity, string i_Pressure)
        {
            try
            {
                float temp = Single.Parse(i_Temp);
                float windSpeed = Single.Parse(i_WindSpeed);
                float humidity = Single.Parse(i_Humidity);
                float pressure = Single.Parse(i_Pressure);
                return new WeatherForcastData(i_City, temp, windSpeed, humidity, pressure);
            }
            catch (Exception ex)
            {
                Console.WriteLine("asdf");
                return null;
            }
        }

        public string getData()
        {
            return m_City + "|" + this.m_Tempreture + "|" + this.m_WindSpeed + "|" + this.m_Humidity + "|" + this.m_Pressure;
        }
    }
}
