using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TutorsHub.Application.Models
{
    public class EditPass
    {

        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "NewPassword")]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,}", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string RepPassword { get; set; }
    }
}