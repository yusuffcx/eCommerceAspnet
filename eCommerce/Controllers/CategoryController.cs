using eCommerce.Contexts;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public List<Category>categories { get; set; }
        public IActionResult Index()
        {
            categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
