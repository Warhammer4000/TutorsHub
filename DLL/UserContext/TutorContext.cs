using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class TutorContext:IUserContext<Tutor>
    {
        public Tutor GetByName(string userName)
        {
            using (var context= new Context())
            {
                return context.Tutors.FirstOrDefault(r => r.UserName == userName);
            }
        }

        public List<Tutor> GetAll()
        {
            using (var context = new Context())
            {
                return context.Tutors.ToList();
            }
        }

        public bool Add(Tutor t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Tutors.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                 
            }
        }

        public bool Update(Tutor t)
        {
            using (var context = new Context())
            {
                try
                {
                    var oldTutor = context.Tutors.First(r => r.UserName == t.UserName);
                    oldTutor.Copy(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public bool Remove(string username)
        {
            using (var context = new Context())
            {
                try
                {
                    var tutor = context.Tutors.First(r => r.UserName == username);
                    context.Tutors.Remove(tutor);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
    }
}
