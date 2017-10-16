using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATP2.Profile.Models
{
    public class EditPasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string RNewPassword { get; set; }
        private string ErrorMessage { get; set; }

        public EditPasswordModel()
        {
            CurrentPassword = "";
            NewPassword = "";
            RNewPassword = "";
            ErrorMessage = "";
        }

        public bool Validate(out string errorMessage)
        {
            bool flag = true;
            if (CurrentPassword == NewPassword)
            {
                ErrorMessage += " New Password should not be same as the Current Password ";
                flag = false;
            }

            if (NewPassword != RNewPassword)
            {
                ErrorMessage += " New Password must match with the Retyped Password ";
                flag = false;
            }

            errorMessage = ErrorMessage;
            return flag;
        }
        

        

    }
}