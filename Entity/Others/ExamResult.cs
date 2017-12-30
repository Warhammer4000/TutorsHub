using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entity.Others
{
    public class ExamResult
    {
        [Key]
        public string Key { get; set; }
        public string TutorName { get; set; }

        public string Result
        {
            get =>JsonConvert.SerializeObject(Results);
            set => Results = JsonConvert.DeserializeObject<List<ResultData>>(value);
        }

        [NotMapped]
        public List<ResultData> Results { get; set; }

        public ExamResult()
        {
            Results= new List<ResultData>();
        }


    }

    public class ResultData
    {
        public string SubjectName { get; set; }
        public int Score { get; set; }
        public int Difficulty { get; set; }
    }

}
