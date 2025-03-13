using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace eCommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly AppDbContext _db;
        private readonly List<ShoppingCart> _products;
        private readonly UserManager<ApplicationUser> _userManager;


        public CartController(AppDbContext db, UserManager<ApplicationUser> userManager)
        {
            _products = new List<ShoppingCart>();
            _db = db;
            _userManager = userManager;
        }

        double getPrice(Product product,int count)
        {
            double price = 0;
            if( count >= 1 && count < 50)
            {
                price = product.ListPrice2 * count;
            }
            else if(count >= 50 && count < 100)
            {
                price = product.ListPrice50 * count;
            }
            else if(count >= 100)
            {
                price = product.ListPrice100 * count;
            }
            return price;
        }

        public IActionResult ViewCart()
        {
            var loggedUserID = _userManager.GetUserId(HttpContext.User);
            List<ShoppingCart>products = _db.ShoppingCarts.Where(c => c.AppUserId == loggedUserID).ToList();

            ShoppingCartViewModel Cart = new ShoppingCartViewModel
            {
                Products = products,
                TotalCount = products.Count(),
                TotalPrice = 0
            };

            for (int i = 0; i < products.Count; i++)
            {
                var product = _db.Products.Where(c => c.Id == products[i].ProductId).FirstOrDefault();
                Cart.TotalPrice = Cart.TotalPrice + getPrice(product, products[i].Count);
            }

            return View(Cart);
        }



        [HttpPost]
        public IActionResult UpdateCount(ShoppingCartViewModel cart,int productId,int count)
        {

            foreach(var product in cart.Products)
            {
                if(product.ProductId == productId)
                {
                    product.Count = count;
                    //var p = _db.ShoppingCarts.SingleOrDefault(p => p.ProductId == productId);
                    _db.ShoppingCarts.Update(product);
                    _db.SaveChanges();
                    break;
                }

            }
            return RedirectToAction("ViewCart");
        }

        public IActionResult Delete(int id)
        {
            var product = _db.ShoppingCarts.Find(id);
            _db.ShoppingCarts.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ViewCart");
        }


    }
}
