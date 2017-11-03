using System;
using System.Collections.Generic;

namespace Entity.UserModels
{
    public class Tutor:User
    {
        public Tutor()
        {
            Role = Role.Tutor;
            PreferredClasses=new List<string>();
            PreferredLocations=new List<string>();
            PreferredMedium=new List<string>();
            PreferredSubjects=new List<string>();
        }

        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public List<String> PreferredMedium { get; set; }
        public List<string> PreferredSubjects { get; set;}
        public List<string> PreferredLocations { get; set;}
        public List<string> PreferredClasses { get; set; }
        public int ExpectedSalary { get; set; }
        public string Bio { get; set; }
        public string CurrentStatus { get; set; }

        public void Copy(Tutor tutor)
        {
            Experience = tutor.Experience;
            Level = tutor.Level;
            Rank = tutor.Rank;
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
