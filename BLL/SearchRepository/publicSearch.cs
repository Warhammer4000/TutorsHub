using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.UserRepository;
using DLL.LogContext;
using Entity.Data;
using Entity.Logs;
using Entity.UserModels;

namespace BLL.SearchRepository
{
    public class PublicSearch
    {
        public List<Tutor> SearchTutors(string location,string gender,string Class,
            int salaryMin,int salaryMax,List<string> selectedSubjects)
        {
            List<Tutor> searchResult=new TutorService().GetAll();
            var logRepo = new LogRepository<SearchLog>().Add(
                new SearchLog
                {
                    Class = Class,
                    Gender = gender,
                    SalaryMax = salaryMax,
                    SalaryMin = salaryMin,
                    Location = location,
                    SubjecList = selectedSubjects
                }
            );
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
