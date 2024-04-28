using ETicaret.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Net8.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        public HomeController(IProductRepository repository)
        {
            productRepository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var getall = await productRepository.GetAllProduct();
            return View(getall);
        }
    }
}
