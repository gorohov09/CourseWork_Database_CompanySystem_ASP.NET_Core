using Microsoft.AspNetCore.Mvc;

namespace Company.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            var name = User.Identity.Name;
            return View();
        }
    }
}