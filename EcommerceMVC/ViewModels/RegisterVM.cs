using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.ViewModels
{
    public class RegisterVM
    {
        [Key]
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters")]
        public string CustomerId { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string FullName { get; set; }

        public bool IsMale { get; set; } = true;

        [Display(Name = "Day of birth")]
        [DataType(DataType.Date)]
        public DateTime? DayOfBirth { get; set; }

        [Display(Name = "Address")]
        [MaxLength(60, ErrorMessage = "Maximum 60 characters")]
        public string Address { get; set; }

        [Display(Name = "Phone number")]
        [MaxLength(24, ErrorMessage = "Maximum 24 characters")]
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Incorrect Vietnamese mobile number format")]
        public string Phone { get; set; }


        [EmailAddress(ErrorMessage = "Incorrect email format")]
		public string Email { get; set; }

        public string? Avatar { get; set; }
    }
}
