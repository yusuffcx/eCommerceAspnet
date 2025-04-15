using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;



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
            int total = 0;
            
            for(int i=0; i<products.Count;i++)
            {
                total = total + products[i].Count;
            }
            Console.WriteLine(total);

            ShoppingCartViewModel Cart = new ShoppingCartViewModel
            {
                Products = products,
                TotalCount = total,
                TotalPrice = 0,
                LoggedUserId = loggedUserID
            };

            for (int i = 0; i < products.Count; i++)
            {
                var product = _db.Products.Where(c => c.Id == products[i].ProductId).FirstOrDefault();
                Cart.TotalPrice = Cart.TotalPrice + getPrice(product, products[i].Count);
            }

            return View(Cart);
        }

        public IActionResult UpdateCount(ShoppingCartViewModel cart,int productId,int count)
        {

            foreach(var product in cart.Products)
            {
                if(product.ProductId == productId)
                {
                    product.Count = count;
                    _db.ShoppingCarts.Update(product);
                    _db.SaveChanges();
                    break;
                }
            }
            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public IActionResult ViewCartToOrderSum(ShoppingCartViewModel shoppingCartJson)
        {
            string json = JsonSerializer.Serialize(shoppingCartJson);

            TempData["cart"] = json;

            return Json( new {success = true});
        }

        public IActionResult OrderSummary()
        {
            if (TempData["cart"] is string json)
            {
                
                var shoppingCartJson = JsonSerializer.Deserialize<ShoppingCartViewModel>(json);
                var userId = shoppingCartJson.LoggedUserId;
                OrderHeader OE = new OrderHeader();
                var loggedUserInfo = _db.ApplicationUsers.FirstOrDefault(a => a.Id == userId);
                shoppingCartJson.OrderHeader = OE;
                shoppingCartJson.OrderHeader.Name = loggedUserInfo.Name;
                shoppingCartJson.OrderHeader.StreetAddress = loggedUserInfo.StreetAddress;
                shoppingCartJson.OrderHeader.PhoneNumber = loggedUserInfo.PhoneNumber;
                shoppingCartJson.OrderHeader.PostalCode = loggedUserInfo.PostalCode;
                shoppingCartJson.OrderHeader.City = loggedUserInfo.City;
                shoppingCartJson.OrderHeader.State = loggedUserInfo.State;
                

                return View(shoppingCartJson);
            }

            /*
            ShoppingCartViewModel vm = new ShoppingCartViewModel
            {
                Products= shoppingCartJson.Products,
                OrderHeader = shoppingCartJson.OrderHeader,
                LoggedUserId = shoppingCartJson.LoggedUserId,
                TotalCount = shoppingCartJson.TotalCount,
                TotalPrice = shoppingCartJson.TotalPrice
            };*/
            return View(new ShoppingCartViewModel());
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
