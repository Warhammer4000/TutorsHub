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
        

        public TutorEditProfileModel()
        {
            Tutor= new Tutor();
            AvailableLocations = new LocationService().GetAll();
        
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

        


        }


    }
}