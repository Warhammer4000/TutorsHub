using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Others;

namespace DLL.ExamContext
{
    public class ResultRepository
    {
        public bool UpdateResult(ExamResult examResult)
        {
            //Add or update
            using (var context = new Context())
            {
                try
                {
                    var temp = context.Results.FirstOrDefault(r => r.Key == examResult.Key);
                    if (temp != null)
                    {
                        temp.Result = examResult.Result;
                    }
                    else
                    {
                        context.Results.Add(examResult);
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }


        public List<ExamResult> Get() => new Context().Set<ExamResult>().ToList();
        public ExamResult Get(string key) => new Context().Set<ExamResult>().FirstOrDefault(r=>r.Key==key);



    }
}
