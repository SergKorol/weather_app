using System.Web.Mvc;
using Weather.Services;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;
        
        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public ActionResult Index()
        {
            //pass model to main page
            return View(_apiService.GetWeatherWidget());
        }
        
        
        public ActionResult About()
        {
            ViewBag.Message = "About author this application";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Serhii Korol";

            return View();
        }
    }
}