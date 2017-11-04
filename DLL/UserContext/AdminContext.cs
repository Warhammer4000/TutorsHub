using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class AdminContext:IUserContext<Admin>
    {
        public Admin GetByName(string userName)
        {
            using (var context = new Context())
            {
                return context.Admins.FirstOrDefault(r => r.UserName == userName);
            }
        }

        public List<Admin> GetAll()
        {
            using (var context = new Context())
            {
                return context.Admins.ToList();
            }
        }

        public bool Add(Admin t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Admins.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public bool Update(Admin t)
        {
            using (var context = new Context())
            {
                try
                {
                    var admin = context.Admins.First(r => r.UserName == t.UserName);
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

        public bool Remove(string userName)
        {
            using (var context = new Context())
            {
                try
                {
                    var tutor = context.Admins.First(r => r.UserName == userName);
                    context.Admins.Remove(tutor);
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
