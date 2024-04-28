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
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductRepository product, ICategoryRepository categoryRepository,IWebHostEnvironment hostEnvironment)
        {
            productRepository = product;
            this.categoryRepository = categoryRepository;
            webHostEnvironment = hostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var getAllProducts = await productRepository.GetAllProduct();
            return View(getAllProducts);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList( categoryRepository.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile? fileUrl)
        {
            ViewBag.CategoryId = new SelectList( categoryRepository.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                //Resim Dosyasının yolunu belirleyip, isimlendirip ve kaydetmek
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if(fileUrl != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUrl.FileName);      //16 karakterlik bir guid oluşturup eklenilen resim dosyasını adına atanıyor
                    string productPath = Path.Combine(wwwRootPath, @"images\products");                      //Resim yolu seçiliyor (kaydedileceği yer)
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        fileUrl.CopyTo(fileStream);
                    }
                    product.ImageUrl = @"\images\products\" + fileName;
                }

                await productRepository.AddAsync(product);
                productRepository.Save();
                TempData["basarili"] = product.Title + " " + "başarılı bir şekilde eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(product);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var FindProduct = await productRepository.GetAsync(x=>x.Id ==id);
            ViewBag.CategoryId = new SelectList( categoryRepository.GetAll(), "Id", "Name");
            return View(FindProduct);
        }
        public async Task<IActionResult> Edit(Product product, IFormFile? fileUrl)
        {
            ViewBag.CategoryId = new SelectList( categoryRepository.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                //Resim Dosyasının yolunu belirleyip, isimlendirip ve kaydetmek
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if (fileUrl != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUrl.FileName);      //16 karakterlik bir guid oluşturup eklenilen resim dosyasını adına atanıyor
                    string productPath = Path.Combine(wwwRootPath, @"images\products");                      //Resim yolu seçiliyor (kaydedileceği yer)
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        fileUrl.CopyTo(fileStream);
                    }
                    product.ImageUrl = @"\images\products\" + fileName;
                }


                productRepository.Update(product);
                productRepository.Save();
                TempData["basarili"] = product.Title+ " " + "başarılı bir şekilde eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(product);
            }
        }

        //API çağırma actionu
        //Action adıyla çağrılabilir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getcall = await productRepository.GetAllProduct();
            return Json(new {data = getcall});
        }
    }
}
