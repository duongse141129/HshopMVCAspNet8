using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Helpers;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		public IActionResult Login(string? returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View(); 
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model, string? returnUrl) 
		{
			ViewBag.ReturnUrl = returnUrl;
			if (ModelState.IsValid)
			{
				var customner = db.Customers.SingleOrDefault(cus => cus.CustomerId == model.UserName);
				if (customner == null)
				{
					ModelState.AddModelError("Error", "This customer was not found");
				}
				else {
					if (!customner.IsActive)
					{
						ModelState.AddModelError("Error", "This account has been locked. Please contact admin");
					}
					else
					{
						if(customner.Password != model.Password.ToMd5Hash(customner.RandomKey))
						{
							ModelState.AddModelError("Error", "Wrong password");
						}
                        else
                        {
							//var claims = new List<Claim> {
							//	new Claim(ClaimTypes.Email, customner.Email),	
							//	new Claim(ClaimTypes.Name, customner.FullName),	
							//	new Claim("CustomerId", customner.CustomerId),	

							//	// claim - role động
							//	new Claim(ClaimTypes.Role, "Customer")
							//};

							//var claimsIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							//var claimsPricipal = new ClaimsPrincipal(claimsIndentity);

							//await HttpContext.SignInAsync(claimsPricipal);
							//if (Url.IsLocalUrl(returnUrl))
							//{
							//	return Redirect(returnUrl);
							//}
							//else
							//{
							//	return Redirect("/");
							//}

							var claims = new List<Claim> {
								new Claim(ClaimTypes.Email, customner.Email),
								new Claim(ClaimTypes.Name, customner.FullName),
								new Claim("CustomerID", customner.CustomerId),

								//claim - role động
								new Claim(ClaimTypes.Role, "Customer")
							};

							var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

							await HttpContext.SignInAsync(claimsPrincipal);

							if (Url.IsLocalUrl(returnUrl))
							{
								return Redirect(returnUrl);
							}
							else
							{
								return Redirect("/");
							}
						}
                    }
				}
			}
			return View();
		}


		[Authorize]
		public IActionResult Profile()
		{
			return View(); 
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}
