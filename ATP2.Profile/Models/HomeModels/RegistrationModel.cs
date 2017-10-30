using System;
using System.ComponentModel.DataAnnotations;

namespace ATP2.Profile.Models.HomeModels
{
    public class RegistrationModel
    {
        [Required, RegularExpression("^[a-zA-Z0-9._-]*$", ErrorMessage = "User Name can contain alpha numeric characters, period, dash or underscore only")]
        [MinLength(2)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,}", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password",ErrorMessage = "Pasword Doesn't Match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

    



    }
}