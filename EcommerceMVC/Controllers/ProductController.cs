using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly Hshop2023Context db;

        public ProductController(Hshop2023Context context) 
        {
            db = context;
        }

        public IActionResult Index(int? category)
        {
            var products = db.Products.AsQueryable();

            if(category.HasValue)
            {
                products = products.Where(p => p.CategoryId == category.Value);
            }

            var result = products.Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price  = p.Price ?? 0,
                ProductPhoto = p.ProductPhoto ?? "",
                ShortDescription = p.Unit ?? "",
                CategoryName = p.Category.CategoryName

            });


            return View(result);
        }

        public ActionResult Search(string? query)
        {
            var products = db.Products.AsQueryable();

            if (query != null)
            {
                products = products.Where(p => p.ProductName.Contains(query));
            }

            var result = products.Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price ?? 0,
                ProductPhoto = p.ProductPhoto ?? "",
                ShortDescription = p.Unit ?? "",
                CategoryName = p.Category.CategoryName

            });


            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var data = db.Products
                        .Include(p => p.Category)
                        .SingleOrDefault(p => p.ProductId == id);
            if(data == null)
            {
                TempData["Message"] = $"Not found product with id: {id}";
                return Redirect("/404");
            }
            var result = new DetailProductVM
            {
                ProductId = data.ProductId,
                ProductName = data.ProductName,
                Price = data.Price ?? 0,
                Description = data.Description ?? string.Empty,
                ProductPhoto = data.ProductPhoto ?? string.Empty,
                ShortDescription = data.Unit,
                CategoryName = data.Category.CategoryName,
                Stock = 10,
                FeedbackPoint = 5,

            };
            return View(result);        
        }



    }
}
