using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATP2.Profile.Models
{
    public class EditProfileModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
    }
}