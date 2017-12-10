using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.UserRepository;
using Entity.Data;
using Entity.UserModels;

namespace BLL.SearchRepository
{
    public class PublicSearch
    {
        public List<Tutor> SearchTutors(string location,string gender,string Class,
            int salaryMin,int salaryMax,List<string> selectedSubjects)
        {
            List<Tutor> searchResult=new TutorService().GetAll();

            searchResult = searchResult.Where(r => r.ExpectedSalary >= salaryMin 
            && r.ExpectedSalary <= salaryMax
            && r.Gender==gender 
            && r.PreferredLocations.Contains(location) 
            && r.PreferredClasses.Contains(Class)
            &&r.PreferredSubjects.Intersect(selectedSubjects).Any()
            ).ToList();

           

            return  searchResult;
        }


    }
}
