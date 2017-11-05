using System.ComponentModel.DataAnnotations;
using Entity.UserModels;

namespace ATP2.Profile.Models.AccountModels
{
    public class EditPasswordModel
    {


        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "New Password")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,}", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string CurrentPassword { get; set; }



        [Required]
        [DataType(DataType.Password)]
      
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "New Password")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,}", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("NewPassword", ErrorMessage = "Pasword Doesn't Match")]
        public string RNewPassword { get; set; }

      
    
    }
}