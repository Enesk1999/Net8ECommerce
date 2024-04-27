using ETicaret.Data.Repos;
using ETicaret.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaret.Net8.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public ProductController(IProductRepository product, ICategoryRepository categoryRepository)
        {
            productRepository = product;
            this.categoryRepository = categoryRepository;

        }
        public async Task<IActionResult> Index()
        {
            var getAllProducts = await productRepository.GetAllAsync();
            return View(getAllProducts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await categoryRepository.GetAllAsync(), "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.CategoryId = new SelectList(await categoryRepository.GetAllAsync(), "Id", "Name");
            if (ModelState.IsValid)
            {
                await productRepository.AddAsync(product);
                productRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(product);
            }
        }
    }
}
