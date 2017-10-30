using System;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace ATP2.Profile.Models.AccountModels
{
    public class ProfileModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public Role Role { get; set; }
        public Status Status { get; set; }
        public DateTime UserSince { get; set; }
    }
}