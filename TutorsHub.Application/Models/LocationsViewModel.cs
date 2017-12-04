using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Data;

namespace TutorsHub.Application.Models
{
    public class LocationsViewModel
    {
        public List<Location> Locations { get; set; } 
        public Location NewLocation { get; set; }

        public LocationsViewModel()
        {
            NewLocation= new Location();
            Locations= new List<Location>();
        }
    }
}