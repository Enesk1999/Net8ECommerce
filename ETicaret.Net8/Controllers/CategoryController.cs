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
            if(category.Name == category.DisplayOrder.ToString())       //Eğer ki Görüntülenme sayısı ile kategori adı aynı ise 
            {
                ModelState.AddModelError("Name", "Kategori Adı ile Görüntülenme Sayısı Aynı Olamaz!!!");
            }

            if (ModelState.IsValid)
            {
                if (category != null)
                {
                    var getQuery = await dbContext.Categories.Where(x => x.DisplayOrder == category.DisplayOrder).FirstOrDefaultAsync();
                    if (getQuery.DisplayOrder==category.DisplayOrder){
                        ModelState.AddModelError("", "tekrardan eklemeyemezsin displayorder sıralamasını zaten var");
                    }
                    else
                    {
                        await dbContext.Categories.AddAsync(category);
                        await dbContext.SaveChangesAsync();
                        TempData["basarili"] = category.Name + " " + "Başarıyla Eklendi";
                        return RedirectToAction("Index", "Category");
                    }
                   
                }
            }
            else
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(category);
            }

            return View();
           
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            if(id==null || id == 0)
            {
                return NotFound();
            }
            // vargetById = await dbContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();    1.Metod
            // var getById = await dbContext.Categories.FindAsync(id);                                  2.Metod
            var getById = await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            return View(getById);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Kategori Adı ile Görüntülenme Sırası Aynı Olamaz");
            }
            if (ModelState.IsValid)
            {
                if(category != null)
                {
                    
                    dbContext.Update(category);
                    await dbContext.SaveChangesAsync();
                    TempData["basarili"] = category.Name + " " + "Başarıyla Güncellendi";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
                
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id==null || id == 0)
            {
                return BadRequest();
            }
            var getByWillDeleteId = await dbContext.Categories.FindAsync(id);
            return View(getByWillDeleteId);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if(category != null)
            {
                TempData["basarili"] = "Başarıyla Kaldırıldı";
                dbContext.Remove(category);
                dbContext.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
