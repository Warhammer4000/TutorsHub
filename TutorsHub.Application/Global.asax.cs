using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;
using BLL.UserRepository;
using Entity.Data;
using Entity.UserModels;

namespace TutorsHub.Application
{
    public class MvcApplication : HttpApplication
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
                UserSince = new DateTime(2002, 4, 10),
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




            ServiceProvider repositoryProvider = new ServiceProvider();
            IUserService<Tutor> iTutor = repositoryProvider.Create<Tutor>();
            IUserService<Admin> iAdmin = repositoryProvider.Create<Admin>();
            iTutor.Add(user);
            iAdmin.Add(user2);

            Fake_data();


        }

        private void Fake_data()
        {
            Admin admin1 = new Admin()
            {
                Name = "James",
                Password = "darks1d1erS!",
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
                Password = "darks1d1erS!",
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
                Password = "darks1d1erS!",
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
                    "English",
                    "Bangla"
                },
                PreferredClasses = new List<string>
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
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
                CurrentStatus = "Student Of AIUB",

            };

            Tutor tutor2 = new Tutor()
            {

                Name = "kamal",
                Email = "kamal@gmail.com",
                Password = "darks1d1erS!",
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
                Password = "darks1d1erS!",
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
                    "Bangla",
                    "English"

                },
                PreferredClasses = new List<string>
                {
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
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
                Password = "darks1d1erS!",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 1, 25),
                UserSince = new DateTime(2006, 7, 1),
                LastLogin = DateTime.Now,
                Status = Status.Active,
                Mobilenumber = "0128972588",
                Address = "mirpur-11"
            };

            Student student2 = new Student()
            {
                Name = "Jihad",
                Email = "jihad@gmail.com",
                Password = "darks1d1erS!",
                Gender = "Male",
                LastLogin = DateTime.Now,
                DateOfBirth = new DateTime(2001, 1, 25),
                UserSince = new DateTime(2006, 7, 1),
                Status = Status.Active,
                Mobilenumber = "0128978598",
                Address = "mirpur-1"
            };
            Student student3 = new Student()
            {
                Name = "Rishad",
                Email = "rishad@gmail.com",
                Password = "darks1d1erS!",
                Gender = "Male",
                LastLogin = DateTime.Now,
                DateOfBirth = new DateTime(2000, 1, 25),
                UserSince = new DateTime(2006, 7, 1),
                Status = Status.Active,
                Mobilenumber = "0128978598",
                Address = "khilkhet"
            };


            ServiceProvider repositoryProvider = new ServiceProvider();
            IUserService<Tutor> iTutor = repositoryProvider.Create<Tutor>();
            IUserService<Admin> iAdmin = repositoryProvider.Create<Admin>();
            IUserService<Student> iStudent = repositoryProvider.Create<Student>();
            iAdmin.Add(admin1);
            iAdmin.Add(admin2);
            iTutor.Add(tutor1);
            iTutor.Add(tutor2);
            iTutor.Add(tutor3);
            iStudent.Add(student1);
            iStudent.Add(student2);
            iStudent.Add(student3);

        }

    }
}

