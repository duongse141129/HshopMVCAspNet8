using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helpers;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private Hshop2023Context db;

        public CartController(Hshop2023Context context) {
            db = context;
        }
        const string CART_KEY = "MYCART";
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault( p => p.ProductId == id);

            //chưa có trong giỏ hàng
            if (item == null)
            {
                var product = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    TempData["Message"] = $"Can not find product with id : {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price ?? 0,
                    ProductPhoto = product.ProductPhoto ?? string.Empty,
                    quantity = quantity
                };
                cart.Add(item);

            }
            else { 
                item.quantity += quantity;
            }
            HttpContext.Session.Set(CART_KEY, cart);


            return RedirectToAction("index");
        }

        public IActionResult RemoveCartItem(int id)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.ProductId==id);
            if (item != null) { 
                cart.Remove(item);
                HttpContext.Session.Set(CART_KEY, cart);
            }

            return RedirectToAction("index");
        }
    }
}
