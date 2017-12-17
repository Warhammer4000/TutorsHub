using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;
using BLL.DataRepositoryFolder;
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
                LastLogin = DateTime.Now,
                ProfilePictureUrl = "../../images/user.png"

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
                LastLogin = DateTime.Now,
                ProfilePictureUrl = "../../images/user.png"
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
                PreferredSubjects = new List<string>()
                {
                    "Bangla",
                    "English" ,
                   "Sociology" ,
                  "Physics" 
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
                PreferredLocations = new List<string>()
                {
                    "Banani" ,
                    "Khilkhet" ,
                   "Mirpur" ,
                    "Tejgaon" 
                },
                ExpectedSalary = 5000,
                Bio = "Student",
                CurrentStatus = "Student Of AIUB",
                ProfilePictureUrl = "../../images/user.png"

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
                PreferredSubjects = new List<string>()
                {
                    "Bangla",
                    "English" ,
                   "Chemistry" ,
                    "Physics" 
                },
                PreferredMedium = new List<string>()
                {
                    "Bangla",
                    "English"
                },
                PreferredClasses = new List<string>
                {
                    "9",
                    "10",
                    "11",
                    "12",
                    "8",
                },
                PreferredLocations = new List<string>()
                {
                    "Banani" ,
                    "Khilkhet" ,
                    "Mirpur" ,
                    "Tejgaon" ,
                },
                ExpectedSalary = 8000,
                Bio = "Student",
                CurrentStatus = Status.Active.ToString(),
                ProfilePictureUrl = "../../images/user.png",

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
                PreferredSubjects = new List<string>()
                {
                    "Bangla" ,
                    "English" ,
                    "Chemistry" ,
                   "Physics" ,
                    "Biology" ,
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
                PreferredLocations = new List<string>()
                {
                  "Mohammodpur" ,
                   "Dhanmondi" ,
                    "Jigatola" ,
                    "New Market" ,
                },
                ExpectedSalary = 9000,
                Bio = "Student",
                CurrentStatus = Status.Active.ToString(),
                ProfilePictureUrl = "../../images/user.png"

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
                Address = "mirpur-11",
                ProfilePictureUrl = "../../images/user.png"
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
                Address = "mirpur-1",
                ProfilePictureUrl = "../../images/user.png"
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
                Address = "khilkhet",
                ProfilePictureUrl = "../../images/user.png"
            };


            Subject subject1= new Subject(){Name = "Bangla" ,Id=1};
            Subject subject2 = new Subject() { Name = "English", Id = 1 };
            Subject subject3 = new Subject() { Name = "Math", Id = 1 };
            Subject subject4 = new Subject() { Name = "Physics", Id = 1 };
            Subject subject5 = new Subject() { Name = "Chemestry", Id = 1 };
            Subject subject6 = new Subject() { Name = "Biology", Id = 1 };
            Subject subject7 = new Subject() { Name = "Social Science", Id = 1 };
            Subject subject8 = new Subject() { Name = "Higher Math", Id = 1 };
            Subject subject9 = new Subject() { Name = "ICT", Id = 1 };


            new SubjectService().Add(subject1);
            new SubjectService().Add(subject2);
            new SubjectService().Add(subject3);
            new SubjectService().Add(subject4);
            new SubjectService().Add(subject5);
            new SubjectService().Add(subject6);
            new SubjectService().Add(subject7);
            new SubjectService().Add(subject8);
            new SubjectService().Add(subject9);

            Location location1 = new Location() { Name = "Mirpur-1", Id = 1 };
            Location location2 = new Location() { Name = "Mirpur-2", Id = 1 };
            Location location3 = new Location() { Name = "Mirpur-6", Id = 1 };
            Location location4 = new Location() { Name = "Mirpur-10", Id = 1 };
            Location location5 = new Location() { Name = "Mirpur-12", Id = 1 };
            Location location6 = new Location() { Name = "Mirpur-11", Id = 1 };
            Location location7 = new Location() { Name = "Mirpur-14", Id = 1 };
            Location location8 = new Location() { Name = "Kalshi", Id = 1 };
            Location location9 = new Location() { Name = "Banani", Id = 1 };
            Location location10 = new Location() { Name = "Farmgate", Id = 1 };
            Location location11 = new Location() { Name = "Bashundhara", Id = 1 };
            Location location12 = new Location() { Name = "Gulshan", Id = 1 };



            new LocationService().Add(location1);
            new LocationService().Add(location2);
            new LocationService().Add(location3);
            new LocationService().Add(location4);
            new LocationService().Add(location5);
            new LocationService().Add(location6);
            new LocationService().Add(location7);
            new LocationService().Add(location8);
            new LocationService().Add(location9);
            new LocationService().Add(location10);
            new LocationService().Add(location11);
            new LocationService().Add(location12);


            





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

