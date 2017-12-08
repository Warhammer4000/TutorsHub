using System;
using System.Collections.Generic;
using System.ComponentModel;
using Entity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.UserModels
{
    public class Tutor:User
    {
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public List<Subject> PreferredSubjects { get; set; }
        public List<Location> PreferredLocations { get; set; }
        public List<string> PreferredMedium { get; set; }
        
        public List<string> PreferredClasses { get; set; }
        public int ExpectedSalary { get; set; }
        public string Bio { get; set; }
        public string CurrentStatus { get; set; }


        public List<Student> Students { get; set; }
        public List<Student> ActiveStudents { get; set; }


        [NotMapped]
        public int LastActiveInSeconds { get; set; }
        [NotMapped]
        public int LastActiveInMinutes { get; set; }
        [NotMapped]
        public int LastActiveInHours { get; set; }
        [NotMapped]
        public int LastActiveInDays { get; set; }
        [NotMapped]
        public int LastActiveInYears { get; set; }

        public Tutor()
        {
            Role = Role.Tutor;
            PreferredClasses = new List<string>();
            PreferredLocations = new List<Location>();
            PreferredMedium = new List<string>();
            PreferredSubjects = new List<Subject>();
            Students= new List<Student>();
            ActiveStudents= new List<Student>();
        }

       

         public override void Copy(User user)
         {
            var tutor = (Tutor) user;
            Name = tutor.Name;
            Email = tutor.Email;
            Mobilenumber = tutor.Mobilenumber;
            Address = tutor.Address;

            PreferredMedium = tutor.PreferredMedium;
            PreferredSubjects = tutor.PreferredSubjects;
            PreferredLocations = tutor.PreferredLocations;
            PreferredClasses = tutor.PreferredClasses;
            ExpectedSalary = tutor.ExpectedSalary;
            Bio = tutor.Bio;
            CurrentStatus = tutor.CurrentStatus;
        }

        public void UpdateInfo()
        {
            DateTime endTime = LastLogin;
            DateTime startTime = DateTime.Now;
            TimeSpan span = startTime.Subtract(endTime);
            LastActiveInSeconds = span.Seconds;
            LastActiveInMinutes = span.Minutes;
            LastActiveInHours = span.Hours;
            LastActiveInDays = span.Days;
        }
    }
}
