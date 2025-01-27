using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace eCommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    //[Route("customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger,AppDbContext db)
        {
            _db = db;
            _logger = logger;
        }
        public IActionResult Index()
        {
            
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            //var products = _db.Products.Include(c => c.category).ToList();
            var product = _db.Products.Include(c => c.category).FirstOrDefault(p => p.Id == id);
            return View(product);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
