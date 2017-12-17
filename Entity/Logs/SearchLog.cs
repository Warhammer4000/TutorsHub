using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logs
{
    public class SearchLog:Log
    {
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public string SubjectsList
        {
            get => string.Join(",", SubjecList);
            set => SubjecList = value.Split(',').ToList();
        }


        [NotMapped]
        public List<string> SubjecList { get; set; }

    }
}
