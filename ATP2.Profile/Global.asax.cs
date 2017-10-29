
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using DLL.Service;
using Entity;


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
            User user = new User()
            {
                DateOfBirth = new DateTime(1995, 4, 29),
                Email = "tkhan@iquantile.com",
                Name = "tazim",
                UserName = "tazim",
                Password = "darks1d1erS!",
                Gender = "Male",
                Role = Role.Admin,
                Status = Status.Active,
                UserSince = new DateTime(2002,4,10)
            };

            User user2 = new User()
            {
                DateOfBirth = new DateTime(1998, 2, 18),
                Email = "lalala@iquantile.com",
                Name = "Afia Ayesha Amin",
                UserName = "lala",
                Password = "darks1d1erS!",
                Gender = "Male",
                Role = Role.User,
                Status = Status.Pending,
                UserSince = new DateTime(2004, 1, 10)
            };

            User user3 = new User()
            {
                DateOfBirth = new DateTime(2000, 1, 5),
                Email = "haha@iquantile.com",
                Name = "Farhanul haque khan",
                UserName = "haha",
                Password = "darks1d1erS!",
                Gender = "Male",
                Role = Role.Executive,
                Status = Status.Blocked,
                UserSince = new DateTime(2010, 11, 12)
            };

            List<User> users = new List<User> {user, user2, user3};
            string x;
            new UserService().AddUser(user,out x);
            new UserService().AddUser(user2, out x);
            new UserService().AddUser(user3, out x);


        }

    }
}

