using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private Hshop2023Context db;

        public CartController(Hshop2023Context context) {
            db = context;
        }
        
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
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
            HttpContext.Session.Set(MySetting.CART_KEY, cart);


            return RedirectToAction("index");
        }

        public IActionResult RemoveCartItem(int id)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.ProductId==id);
            if (item != null) { 
                cart.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, cart);
            }

            return RedirectToAction("index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
           
            if (Cart.Count == 0) {
                return Redirect("/");
            }

            return View(Cart); 
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckOut(CheckOutVM model)
        {

            if (ModelState.IsValid)
            {
                var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;

                var customer = new Customer();
                if (model.SameCustomer)
                {
                    customer = db.Customers.SingleOrDefault(cus => cus.CustomerId == customerId);

                }

                var order = new Order
                {
                    CustomerId = customerId,
                    FullName = model.FullName ?? customer.FullName,
                    AddressDelivery = model.DeliveryAddress ?? customer.Address,
                    PhoneDelivery = model.Phone ?? customer.Phone,
                    DateOrder = DateTime.Now,
                    PaymentMethod = "COD",
                    DeliveryMethod = "Shoppee Express",
                    TrackingId = 0,
                    Note = model.Note


                };

                //chi tiet hoa don
                db.Database.BeginTransaction();
                try
                {

                    db.Database.CommitTransaction();
                    db.Add(order);
                    db.SaveChanges();

                    var orderDetails = new List<OrderDetail>();
                    foreach (var item in Cart)
                    {
                        orderDetails.Add(new OrderDetail
                        {
                            OrderId = order.OrderId,
                            Quantity = item.quantity,
                            Price = item.Price,
                            ProductId = item.ProductId,
                            Discount = 0
                        });
                    }
                    db.AddRange(orderDetails);
                    db.SaveChanges();

                    HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

                    return View("Success");

                }
                catch 
                {
                    {
                        db.Database.RollbackTransaction();
                    }
                }

               
            }
            return View(Cart);
        }
    }
}
