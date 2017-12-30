using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.ExamContext;
using Entity.Others;

namespace BLL.Exam
{
    public class ResultService
    {
        public ExamResult Get(string key)=>new ResultRepository().Get(key);
        public List<ExamResult> Get() => new ResultRepository().Get();
        public bool UpdateResult(ExamResult examResult)=>new ResultRepository().UpdateResult(examResult);


    }
}
