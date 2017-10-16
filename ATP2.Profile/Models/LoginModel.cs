using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ATP2.Profile.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private string ErrorMessage { get; set; }

        public LoginModel()
        {
            UserName = "";
            Password = "";
            ErrorMessage = "";
        }

        public bool Validation(out string errorMessage)
        {
            errorMessage = "";
            if ( ValidateUserName(UserName) && ValidatePassword(Password))
            {
                return true;
            }
            errorMessage = ErrorMessage;
            return false;
        }


        private bool HasSpecialChar(string input)
        {
            string specialChar = @"#$%";
            return input != null && specialChar.Any(input.Contains);
        }

        private bool ValidatePassword(string password)
        {
            bool flag = true;
            if (password?.Length<8)
            {
                ErrorMessage += " Password must not be less than eight (8) characters </br>";
                flag = false;
            }

            if (!HasSpecialChar(password))
            {
                ErrorMessage += " Password must contain at least one of the special characters (@, #, $, %) </br>";
                flag = false;
            }

            return flag;
        }


       


        private bool ValidateUserName(string userName)
        {
            bool flag = true;
            if (userName?.Length < 2)
            {
                ErrorMessage += " User Name must contain at least two (2) characters </br>";
                flag = false;
            }

            if (userName != null && Regex.IsMatch(userName, "[^A-Za-z0-9._-]"))
            {
                ErrorMessage += " User Name can contain alpha numeric characters, period, dash or underscore only </br>";
                flag = false;
            }

            return flag;
        }


    }
}