using System.Web;

namespace ATP2.Profile.Models.AccountModels
{
    public class ProfilePictureModel
    {
       public string UserName { get; set; }

     
        public HttpPostedFileBase Picture { get; set; }

       

        public bool Validation(out string errorMessage)
        {
            bool flag = true;
            errorMessage = "";
        
            //MVC throws exception if 4MB anyway no need to check
            if (Picture.ContentLength > 4 * 1024 * 1024)
            {
                errorMessage += Picture.ContentLength + "Is too Big";
                flag = false;
            }


            if (Picture.ContentType.ToLower() != "image/jpg" &&
                Picture.ContentType.ToLower() != "image/jpeg" &&
                Picture.ContentType.ToLower() != "image/png")
            {
                flag = false;
                errorMessage += Picture.ContentType + " is Invalid";
            }
            return flag;
        }

    }
}