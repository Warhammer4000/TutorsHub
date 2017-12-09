using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepositoryFolder;
using BLL.UserRepository;
using Entity.Data;
using Entity.UserModels;

namespace TutorsHub.Application.Models
{
    public class TutorEditProfileModel
    {
        public Tutor Tutor { get; set; }
        public List<Location> AvailableLocations { get; set; }
        public List<Class> Classes { get; set; }
        public List<Medium> Mediums { get; set; }

        public TutorEditProfileModel()
        {
            Tutor= new Tutor();
            AvailableLocations = new LocationService().GetAll();
            Classes= new List<Class>();
            for (int i = 1; i <= 12; i++)
            {
                Classes.Add(new Class(){Name = i.ToString()});
            }
            Mediums = new List<Medium> {new Medium() {Name = "English"}, new Medium() {Name = "Bangla"}};
        }

        public void GetTutor(string id)
        {
            Tutor= new TutorService().GetByEmailWithLists(id);
            foreach (var location in Tutor.PreferredLocations)
            {
                foreach (var availableLocation in AvailableLocations)
                {
                    if (availableLocation.Name==location.Name)
                    {
                        availableLocation.IsChecked = true;
                    }
                }
            }

            foreach (var preferredClass in Tutor.PreferredClasses)
            {
                foreach (var c in Classes)
                {
                    if (c.Name == preferredClass)
                    {
                        c.IsChecked = true;
                    }
                   
                }
            }

            foreach (var preferredMediums in Tutor.PreferredMedium)
            {
                foreach (var c in Mediums)
                {
                    if (c.Name == preferredMediums)
                    {
                        c.IsChecked = true;
                    }

                }
            }


        }

       


    }
}