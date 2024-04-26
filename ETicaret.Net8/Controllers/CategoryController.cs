using ETicaret.Data.Repos;
using ETicaret.Net8.Data;
using ETicaret.Net8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Net8.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext dbContext; UnitofWorke geçiş
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository cr)
        {
            categoryRepository = cr;
        }
        public async Task<IActionResult> Index()
        {
            var getAll= await categoryRepository.GetAllAsync();
            return View(getAll);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category? category)
        {
            if(category.Name == category.DisplayOrder.ToString())       //Eğer ki Görüntülenme sayısı ile kategori adı aynı ise 
            {
                ModelState.AddModelError("Name", "Kategori Adı ile Görüntülenme Sayısı Aynı Olamaz!!!");
            }

            if (ModelState.IsValid)
            {
                if (category != null)
                {
                 
                    await categoryRepository.AddAsync(category);
                    categoryRepository.Save();
                    TempData["basarili"] = category.Name + " " + "Başarıyla Eklendi";
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            if(id==null || id == 0)
            {
                return NotFound();
            }
            // vargetById = await dbContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();    1.Metod
            // var getById = await dbContext.Categories.FindAsync(id);                                  2.Metod
            var getById = await categoryRepository.GetAsync(x=>x.Id==id);
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
                    
                    categoryRepository.Update(category);
                    categoryRepository.Save();
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
            var getByWillDeleteId = await categoryRepository.GetAsync(x=>x.Id==id);
            return View(getByWillDeleteId);
        }
        [HttpPost]
        public IActionResult Delete(Category category)      //model binding ile categorydeki elemanları görme
        {
            if(category != null)
            {
                TempData["basarili"] = "Başarıyla Kaldırıldı";
                categoryRepository.Remove(category);
                categoryRepository.Save();
               
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
