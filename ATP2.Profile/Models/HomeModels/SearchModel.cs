using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepository;
using Entity.Data;

namespace ATP2.Profile.Models.HomeModels
{
    public class SearchModel
    {
        public List<Subject> Subjects { get; set; }
        public List<Location> Locations { get; set; }

        public SearchModel()
        {
            Subjects=new SubjectRepository().GetAll();
            Locations= new LocationRepostiory().GetAll();
        }
    }
}