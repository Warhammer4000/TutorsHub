
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BLL.UserRepository;
using Entity;
using Entity.UserModels;


namespace ATP2.Profile
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }


        protected void Session_Start()
        {
            var user = new Tutor()
            {
                DateOfBirth = new DateTime(1995, 4, 29),
                Email = "tkhan@iquantile.com",
                Name = "tazim",
                UserName = "tazim",
                Password = "darks1d1erS!",
                Gender = "Male",
                Status = Status.Pending,
                UserSince = new DateTime(2002,4,10),
                LastLogin = DateTime.Now
                
            };

            var user2 = new Admin()
            {
                DateOfBirth = new DateTime(1998, 2, 18),
                Email = "lalala@iquantile.com",
                Name = "Afia Ayesha Amin",
                UserName = "lala",
                Password = "darks1d1erS!",
                Gender = "Male",
                Status = Status.Active,
                UserSince = new DateTime(2004, 1, 10),
                LastLogin = DateTime.Now
            };

         

            
            
            new TutorRepository().Add(user);
            new AdminRepository().Add(user2);
          
           


        }

    }
}

