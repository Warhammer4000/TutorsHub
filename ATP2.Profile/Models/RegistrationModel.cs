using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ATP2.Profile.Models
{
    public class RegistrationModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        private string ErrorMessage { get; set; }


        public bool Validation(out string errorMessage)
        {
            errorMessage = "";
            if (ValidateUserName() && ValidatePassword() &&ValidateEmail())
            {
                return true;
            }
            errorMessage = ErrorMessage;
            return false;
        }

        private bool ValidateUserName()
        {
            bool flag = true;
            if (UserName?.Length < 2)
            {
                ErrorMessage += " User Name must contain at least two (2) characters </br>";
                flag = false;
            }

            if (UserName != null && Regex.IsMatch(UserName, "[^A-Za-z0-9._-]"))
            {
                ErrorMessage += " User Name can contain alpha numeric characters, period, dash or underscore only </br>";
                flag = false;
            }

            return flag;
        }

        private bool HasSpecialChar(string input)
        {
            string specialChar = @"#$%";
            return input != null && specialChar.Any(input.Contains);
        }

        private bool ValidatePassword()
        {
            bool flag = true;
            if (Password?.Length < 8)
            {
                ErrorMessage += " Password must not be less than eight (8) characters </br>";
                flag = false;
            }

            if (!HasSpecialChar(Password))
            {
                ErrorMessage += " Password must contain at least one of the special characters (@, #, $, %) </br>";
                flag = false;
            }


            if (Password != ConfirmPassword)
            {
                ErrorMessage += " New Password must match with the Confirm Password ";
                flag = false;
            }


            return flag;
        }

        private bool ValidateEmail()
        {
            if (new EmailAddressAttribute().IsValid(Email))
            {
                return true;
            }
            else
            {
                ErrorMessage += " Invalid Email";
                return false;
            }
        }



    }
}