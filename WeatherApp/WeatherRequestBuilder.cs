using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    class WeatherRequestBuilder
    {
        private const String k_APIKey = "1b897478b62b70fcd3d357fb0bccdfbe";
        private const String k_PrefixToQuery = "https://api.openweathermap.org/data/2.5/weather?q=";

        public static string GetRequest(string i_City)
        {
            return getStrCityWeatherRequest(i_City);
        }

        public static string GetRequestMetricUnits(string i_City)
        {
            string request = getStrCityWeatherRequest(i_City);
            return addMetricUnits(request);
        }

        public static string GetRequestImperialUnits(string i_City)
        {
            string request = getStrCityWeatherRequest(i_City);
            return addImperialUnits(request);
        }

        private static string getStrCityWeatherRequest(string i_City)
        {
            StringBuilder requestStrBuilder = new StringBuilder(k_PrefixToQuery);
            requestStrBuilder.Append(i_City);
            requestStrBuilder.Append("&appid=");
            requestStrBuilder.Append(k_APIKey);
            return requestStrBuilder.ToString();
        }
        private static string getRequestJSON(string i_Request)
        {
            return i_Request;
        }

        private static string getRequestHTML(string i_Request)
        {
            return addParamToRequest(i_Request, "mode", "html");
        }

        private static string getRequestXML(string i_Request)
        {
            return addParamToRequest(i_Request, "mode", "xml");
        }

        private static string addMetricUnits(string i_Request)
        {
            return addParamToRequest(i_Request, "units", "metric");
        }

        private static string addImperialUnits(string i_Request)
        {
            return addParamToRequest(i_Request, "units", "imperial");
        }

        private static string addParamToRequest(string i_Request, string i_Param, string i_ParamValue)
        {
            return i_Request + "&" + i_Param + "=" + i_ParamValue;
        }
    }
}
