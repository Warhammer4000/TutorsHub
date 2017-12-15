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

            searchResult = searchResult.Where(r => r.ExpectedSalary >= salaryMin ).ToList();
            searchResult= searchResult.Where(r=>r.ExpectedSalary<=salaryMax).ToList();
            searchResult=searchResult.Where(r=>r.Gender==gender).ToList();
            searchResult=searchResult.Where(r=>r.PreferredLocations.Contains(location)).ToList();
            searchResult=searchResult.Where(r=>r.PreferredClasses.Contains(Class)).ToList();
            searchResult = searchResult.Where(r => r.PreferredSubjects.Intersect(selectedSubjects).Any()).ToList();
           
            return  searchResult;
        }


    }
}
