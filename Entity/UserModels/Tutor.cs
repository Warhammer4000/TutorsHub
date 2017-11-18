using System;
using System.Collections.Generic;
using System.ComponentModel;
using Entity.Data;

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


        public Tutor()
        {
            Role = Role.Tutor;
            PreferredClasses = new List<string>();
            PreferredLocations = new List<Location>();
            PreferredMedium = new List<string>();
            PreferredSubjects = new List<Subject>();
            
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
    }
}
