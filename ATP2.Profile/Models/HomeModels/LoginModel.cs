using System.ComponentModel.DataAnnotations;
using Entity.UserModels;

namespace ATP2.Profile.Models.HomeModels
{
    public class LoginModel
    {
        [Required,RegularExpression("^[a-zA-Z0-9._-]*$", ErrorMessage = "User Name can contain alpha numeric characters, period, dash or underscore only")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,}", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public Role Role { get; set; }


    }
}