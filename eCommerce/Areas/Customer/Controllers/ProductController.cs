using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _web;

        [ActivatorUtilitiesConstructor]
        public ProductController(AppDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _web = web;
        }


        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            products = _db.Products.ToList();
            return products;
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>();

            categories = _db.Categories.ToList();

            return categories;
        }

        public IActionResult Index()
        {
            var products = _db.Products.Include(p => p.category).OrderBy(p => p.category.DisplayOrder).ToList();
                //ToList();
            return View(products);
        }

        public IActionResult Add()
        {
            ViewData["Products"] = GetProducts();
            ViewData["Categories"] = GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product,IFormFile? file)
        {
            if(file!= null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(_web.WebRootPath, @"images\product");

                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                product.ImageUrl = @"images\product\" + fileName;
            }
            _db.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _db.Products.FirstOrDefault(product => product.Id == id);
            ViewData["Products"] = GetProducts();
            ViewData["Categories"] = GetCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product NewProduct, IFormFile? file)
        {
            if (file != null)
            {
                if(NewProduct.ImageUrl != null)
                {
                    string oldPath = Path.Combine(_web.WebRootPath, NewProduct.ImageUrl);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(_web.WebRootPath, @"images\product");

                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                NewProduct.ImageUrl = @"images\product\" + fileName;
            }

            _db.Products.Update(NewProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}



