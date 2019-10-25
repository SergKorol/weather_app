using System;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Weather.Models;

namespace Weather.Services
{
    public class ApiService
    {
        private string _apiResponse;
        private const string Apikey = "468a503ea1fb7b213d5d77f5bd066c60";
        
        public WeatherWidget GetWeatherWidget()
        {
            IpInfo ipInfo = GetLocationByIp();
            RegionInfo region = GetRegionCode(ipInfo.Country);
            //Request to OpenWeatherMap API 
            var apiRequest = WebRequest.Create(
                $"https://api.openweathermap.org/data/2.5/weather?q={ipInfo.City},{region}&APPID={Apikey}&units=metric");
            
            //Get response from OpenWeatherMap
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    StreamReader reader = 
                        new StreamReader(response.GetResponseStream() ?? throw new Exception("Fail response"));
                    _apiResponse = reader.ReadToEnd();
                }
            }
            
            //convert for model
            WeatherWidget weatherWidget = JsonConvert.DeserializeObject<WeatherWidget>(_apiResponse);

            return weatherWidget;
        }
        
        private IpInfo GetLocationByIp()
        {
            //Get external IP
            string ip = new WebClient().DownloadString("http://ifconfig.me");
            //Get info about IP
            string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
            //Conversion to object
            IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

            return ipInfo;
        }

        private RegionInfo GetRegionCode(string fullCountryName)
        {
            //Get reduced country name
            RegionInfo regionCode = new RegionInfo(fullCountryName);

            return regionCode;
        }

        
    }
}