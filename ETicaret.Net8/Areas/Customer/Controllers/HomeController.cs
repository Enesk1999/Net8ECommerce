using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Net8.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ss=12;
            return View();
        }
    }
}
