using System;
using System.Collections.Generic;
using System.ComponentModel;
using Entity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Entity.BlogModel;
using Entity.Others;
using Newtonsoft.Json;

namespace Entity.UserModels
{
    public class Tutor:User
    {
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }

        [NotMapped]
        public List<string> PreferredSubjects { get; set; }
        //BECAUSE No more coupling
        public string SubjectsList
        {
            get => string.Join(",", PreferredSubjects);
            set => PreferredSubjects = value.Split(',').ToList();
        }

        [NotMapped]
        public List<string> PreferredLocations { get; set; }
        public string LocationsList
        {
            get => string.Join(",", PreferredLocations);
            set => PreferredLocations = value.Split(',').ToList();
        }



        [NotMapped]
        public List<string> PreferredMedium { get; set; }

        //BECAUSE EF can't store Primitve types
        public string Mediums
        {
            get => string.Join(",", PreferredMedium);
            set => PreferredMedium = value.Split(',').ToList();
        }



        [NotMapped]
        public List<string> PreferredClasses { get; set; }

        //BECAUSE EF can't store Primitve types
        public string Classes
        {
            get => string.Join(",", PreferredClasses);
            set => PreferredClasses = value.Split(',').ToList();
        }

        public double AvailableBalance { get; set; }
        public double OnHoldBalance { get; set; }

        public int ExpectedSalary { get; set; }
        public string Bio { get; set; }
        public string CurrentStatus { get; set; }

        [NotMapped]
        public List<Student> Students { get; set; }
        [NotMapped]
        public List<Student> ActiveStudents { get; set; }

        [NotMapped]
        public List<Blog> Blogs { get; set; }

        [NotMapped]
        public List<ProposedSchedule> Schedules { get; set; }
        public string Schedule
        {
            get => JsonConvert.SerializeObject(Schedules);
            set => Schedules = string.IsNullOrEmpty(value) ? new List<ProposedSchedule>() : JsonConvert.DeserializeObject<List<ProposedSchedule>>(value);
        }

        public string ActiveStudenList {
            get => JsonConvert.SerializeObject(ActiveStudents);
            set => ActiveStudents = string.IsNullOrEmpty(value) ? new List<Student>() : JsonConvert.DeserializeObject<List<Student>>(value);
        }
        public string StudentList {
            get => JsonConvert.SerializeObject(Students);
            set => Students = string.IsNullOrEmpty(value) ? new List<Student>() : JsonConvert.DeserializeObject<List<Student>>(value);
        }

      

        public Tutor()
        {
            Role = Role.Tutor;
            PreferredClasses = new List<string>();
            PreferredLocations = new List<string>();
            PreferredMedium = new List<string>();
            PreferredSubjects = new List<string>();
            Students= new List<Student>();
            ActiveStudents= new List<Student>();
            Schedules= new List<ProposedSchedule>();
        }

       

         public override User Copy(User user)
         {
            var tutor = (Tutor) user;
            Name = tutor.Name;
            Mobilenumber = tutor.Mobilenumber;
            Address = tutor.Address;
            Gender = tutor.Gender;

            PreferredMedium = tutor.PreferredMedium;
            PreferredSubjects = tutor.PreferredSubjects;
            PreferredLocations = tutor.PreferredLocations;
            PreferredClasses = tutor.PreferredClasses;
            ExpectedSalary = tutor.ExpectedSalary;
            Bio = tutor.Bio;
            CurrentStatus = tutor.CurrentStatus;
            Schedule = tutor.Schedule;
            Students = tutor.Students;
            ActiveStudents = tutor.ActiveStudents;
            return this;
         }

       
    }
}
