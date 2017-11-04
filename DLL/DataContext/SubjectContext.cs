using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entity.Data;

namespace DLL.DataContext
{
    public class SubjectContext:IDataContext<Subject>
    {
        public List<Subject> GetAll()
        {
            using (var context= new Context())
            {
                return context.Subjects.ToList();
            }
        }

        public Subject GetWithTutors(string subjectName)
        {
            using (var context = new Context())
            {
                return context.Subjects.Include(x=>x.Tutors).FirstOrDefault(r=>r.Name==subjectName);
            }
        }

        public bool Add(Subject t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Subjects.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool Update(Subject t)
        {
            throw new NotImplementedException();
        }
    }
}
