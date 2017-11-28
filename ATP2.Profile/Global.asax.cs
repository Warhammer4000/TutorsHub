using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BLL.UserRepository;
using Entity.Data;
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
       
                Password = "darks1d1erS!",
                Gender = "Male",
                Status = Status.Active,
                UserSince = new DateTime(2004, 1, 10),
                LastLogin = DateTime.Now
            };

         

            
            
            new TutorRepository().Add(user);
            new AdminRepository().Add(user2);
          
           


        }

        public void Fake_data()
        {
            Admin admin1 = new Admin()
            {
                Name = "James",
                Password = "hello1234",
                Email = "admin@gmail.com",
                Gender = "Male",
                DateOfBirth = new DateTime(1995, 2, 18),
                Status = Status.Active,
                UserSince = new DateTime(2005, 1, 10),
                LastLogin = DateTime.Now
            };
            Admin admin2 = new Admin()
            {
                Name = "Jake",
                Password = "Jake1234",
                Email = "jake@gmail.com",
                Gender = "Male",
                DateOfBirth = new DateTime(1993, 2, 18),
                Status = Status.Active,
                UserSince = new DateTime(2003, 1, 10),
                LastLogin = DateTime.Now
            };

            Tutor tutor1 = new Tutor()
            {

                Name = "Jamal",
                Email = "jamal@gmail.com",
                Password = "jamal1234",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 25),
                Status = Status.Active,
                UserSince = new DateTime(2009, 7, 1),
                LastLogin = DateTime.Now,
                Experience = 1,
                Level = 1,
                Rank = 155,
                PreferredSubjects = new List<Subject>()
                {
                    new Subject() {Name="Bangla" },
                    new Subject() {Name="English" },
                    new Subject() {Name="Sociology" },
                    new Subject() {Name="Physics" }
                },
                PreferredMedium = new List<string>()
                {
                    "English Medium",
                    "English Version"
                },
                PreferredClasses = new List<string>
                {
                    "class-1",
                    "class-2",
                    "class-3",
                    "class-4",
                    "class-5",
                },
                PreferredLocations = new List<Location>()
                {
                    new Location() {Name="Banani" },
                    new Location() {Name="Khilkhet" },
                    new Location() {Name="Mirpur" },
                    new Location() {Name="Tejgaon" },
                },
                ExpectedSalary = 5000,
                Bio = "Student",
                CurrentStatus = Status.Active.ToString(),
                
            };

            Tutor tutor2 = new Tutor()
            {

                Name = "kamal",
                Email = "kamal@gmail.com",
                Password = "kamal1234",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 25),
                Status = Status.Active,
                UserSince = new DateTime(2009, 7, 1),
                LastLogin = DateTime.Now,
                Experience = 2,
                Level = 3,
                Rank = 99,
                PreferredSubjects = new List<Subject>()
                {
                    new Subject() {Name="Bangla" },
                    new Subject() {Name="English" },
                    new Subject() {Name="Chemistry" },
                    new Subject() {Name="Physics" }
                },
                PreferredMedium = new List<string>()
                {
                    "Bangla Medium",
                    "English Version"
                },
                PreferredClasses = new List<string>
                {
                    "class-9",
                    "class-10",
                    "class-11",
                    "class-12",
                    "class-8",
                },
                PreferredLocations = new List<Location>()
                {
                    new Location() {Name="Banani" },
                    new Location() {Name="Khilkhet" },
                    new Location() {Name="Mirpur" },
                    new Location() {Name="Tejgaon" },
                },
                ExpectedSalary = 8000,
                Bio = "Student",
                CurrentStatus = Status.Active.ToString(),

            };

            Tutor tutor3 = new Tutor()
            {

                Name = "Bimal",
                Email = "bimal@gmail.com",
                Password = "Bimal1234",
                Gender = "Male",
                DateOfBirth = new DateTime(1993, 1, 25),
                Status = Status.Active,
                UserSince = new DateTime(2006, 7, 1),
                LastLogin = DateTime.Now,
                Experience = 5,
                Level = 4,
                Rank = 5,
                PreferredSubjects = new List<Subject>()
                {
                    new Subject() {Name="Bangla" },
                    new Subject() {Name="English" },
                    new Subject() {Name="Chemistry" },
                    new Subject() {Name="Physics" },
                    new Subject() {Name="Biology" },
                },
                PreferredMedium = new List<string>()
                {
                    "Bangla Medium",
                    "English Version",
                    "English Medium"
                },
                PreferredClasses = new List<string>
                {
                    "class-8",
                    "class-9",
                    "class-10",
                    "class-11",
                    "class-12"
                },
                PreferredLocations = new List<Location>()
                {
                    new Location() {Name="Mohammodpur" },
                    new Location() {Name="Dhanmondi" },
                    new Location() {Name="Jigatola" },
                    new Location() {Name="New Market" },
                },
                ExpectedSalary = 9000,
                Bio = "Student",
                CurrentStatus = Status.Active.ToString(),

            };

            Student student1 = new Student()
            {
                Name = "Jahid",
                Email = "jahid@gmail.com",
                Password = "jahidl1234",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 1, 25),
                Status = Status.Active,
                Mobilenumber = "0128972588",
                Address = "mirpur-11"
            };

            Student student2 = new Student()
            {
                Name = "Jihad",
                Email = "jihad@gmail.com",
                Password = "jihadl1234",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 25),
                Status = Status.Active,
                Mobilenumber = "0128978598",
                Address = "mirpur-1"
            };
            Student student3 = new Student()
            {
                Name = "Rishad",
                Email = "rishad@gmail.com",
                Password = "rishadl1234",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 1, 25),
                Status = Status.Active,
                Mobilenumber = "0128978598",
                Address = "khilkhet"
            };


            new AdminRepository().Add(admin1);
            new AdminRepository().Add(admin2);
            new TutorRepository().Add(tutor1);
            new TutorRepository().Add(tutor2);
            new TutorRepository().Add(tutor3);
            

        }

    }
}

