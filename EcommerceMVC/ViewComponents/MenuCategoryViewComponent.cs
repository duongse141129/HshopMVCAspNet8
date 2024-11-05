using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.ViewComponents
{
    public class MenuCategoryViewComponent : ViewComponent
    {
        private readonly Hshop2023Context db;

        public MenuCategoryViewComponent(Hshop2023Context context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Categories.Select(category => new MenuCategoryVM
            {
                CategoryId = category.CategoryId, 
                CategoryName = category.CategoryName, 
                Quantity = category.Products.Count 
            }).OrderBy(p => p.CategoryName);

            return View(data); //Default.cshtml
            //return View("Default", data); 

        }
    }
}
