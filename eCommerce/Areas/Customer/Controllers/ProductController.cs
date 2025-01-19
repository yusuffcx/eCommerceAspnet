using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
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
        public IActionResult Add(Product product)
        {
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
        public IActionResult Edit(Product NewProduct)
        {
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



