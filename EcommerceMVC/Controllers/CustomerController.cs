using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Helpers;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Hshop2023Context db;
		private readonly IMapper _mapper;

		public CustomerController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Register(RegisterVM model, IFormFile photo)
		{
			// <Nullable>enable</Nullable>
			if (ModelState.IsValid)
            {
                try
                {
					var customer = _mapper.Map<Customer>(model);
					customer.RandomKey = MyUtil.GenerateRamdomKey();
					customer.Password = model.Password.ToMd5Hash(customer.RandomKey);
					customer.IsActive = true;
					customer.Role = 0;

					if (photo != null)
					{
						customer.Avatar = MyUtil.UploadPhoto(photo, "KhachHang");
					}

					db.Add(customer);
					db.SaveChanges();
					return RedirectToAction("Index", "Product");
				}
                catch (Exception ex) 
                {
					var mess = $"{ex.Message} shh";
				}

                


			}
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{

			return View(); 
		}
	}
}
