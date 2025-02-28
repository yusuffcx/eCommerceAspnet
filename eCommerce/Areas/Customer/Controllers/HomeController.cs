using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,AppDbContext db,UserManager<ApplicationUser>userManager)
        {
            _userManager = userManager;
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
            ShoppingCart cart = new ShoppingCart();
            cart.ProductId = id;
            cart.Product = _db.Products.Include(c => c.category).FirstOrDefault(p => p.Id == id);
            cart.AppUserId = _userManager.GetUserId(HttpContext.User);
            cart.Count = 1;
            Console.WriteLine(cart);
            var product = _db.ShoppingCarts.Include(c => c.Product).FirstOrDefault(p => p.Id == id);
            
            return View(cart);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            cart.AppUserId = _userManager.GetUserId(HttpContext.User);
            _db.ShoppingCarts.Add(cart);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
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
