using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int? category)
        {
            return View();
        }
    }
}
