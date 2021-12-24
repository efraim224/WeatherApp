using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp
{
    class RequestHandler
    {
        string m_Request;

        public RequestHandler(string i_Request)
        {
            this.m_Request = i_Request;
        }

        public string GetJsonAsStr()
        {
            try
            {
                HttpWebRequest webRequest = WebRequest.Create(this.m_Request) as HttpWebRequest;
                if (webRequest == null)
                {
                    return null;
                }
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                Stream stream = webRequest.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string jsonStr = sr.ReadToEnd();
                return jsonStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
