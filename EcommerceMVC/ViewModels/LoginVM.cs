using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "User Name")]
		[Required(ErrorMessage = "User Name can't empty")]
		[MaxLength(20, ErrorMessage = "Maximum 20 characters")]
		public string UserName { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password can't empty ")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
