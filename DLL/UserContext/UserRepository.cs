using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class UserRepository<T> where T : User
    {
        public T GetByEmail(string email)
        {
            using (var context = new Context())
            {
                return context.Set<T>().FirstOrDefault(r => r.Email == email);
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

        public bool Remove(string email)
        {
            using (var context = new Context())
            {
                try
                {
                    var tutor = context.Set<T>().First(r => r.Email == email);
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
                    var admin = context.Set<T>().First(r => r.Email == t.Email);
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
