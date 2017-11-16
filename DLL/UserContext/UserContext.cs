using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class UserContext<T> where T : User
    {
        public T GetByName(string userName)
        {
            using (var context = new Context())
            {
                return context.Set<T>().FirstOrDefault(r => r.UserName == userName);
            }
        }

        public List<T> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public bool Add(T t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Set<T>().Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public bool Remove(string userName)
        {
            using (var context = new Context())
            {
                try
                {
                    var tutor = context.Set<T>().First(r => r.UserName == userName);
                    context.Set<T>().Remove(tutor);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }


        public bool Update(T t)
        {
            using (var context = new Context())
            {
                try
                {
                    var admin = context.Set<T>().First(r => r.UserName == t.UserName);
                    admin.Copy(t);
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
