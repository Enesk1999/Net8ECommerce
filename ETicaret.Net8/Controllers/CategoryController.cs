using ETicaret.Net8.Data;
using ETicaret.Net8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Net8.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryController(ApplicationDbContext application)
        {
            dbContext = application;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await dbContext.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category != null)
                {
                    await dbContext.Categories.AddAsync(category);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Index", "Category");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(category);
            }

            return View();
           
        }
    }
}
