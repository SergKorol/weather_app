using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        
        public ActionResult Index()
        {
            string ip = new WebClient().DownloadString("http://ifconfig.me");
            string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
            var ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRI1.EnglishName;
            string apiKey = "468a503ea1fb7b213d5d77f5bd066c60";
            var apiRequest = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=468a503ea1fb7b213d5d77f5bd066c60");

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}