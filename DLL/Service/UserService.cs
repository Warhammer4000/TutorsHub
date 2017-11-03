using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.UserModels;

namespace DLL.Service
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            using (var context = new Context())
            {
                return context.Users.ToList();
            }
        }

        public User GetUserByUserName(string userName)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(r => r.UserName==userName);
            }
        }


        public bool AddUser(User user,out string error)
        {
            using (var context = new Context())
            {
                error = "";
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    error = e.Message;
                    return false;
                }
            }
        }

        public bool RemoveUser(User user, out string error)
        {
            using (var context = new Context())
            {
                error = "";
                try
                {
                    var item = context.Set<User>().FirstOrDefault(r => r.UserName == user.UserName);
                    if (item == null) return false;
                    context.Users.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    error = e.Message;
                    return false;
                }
            }
        }

        public bool Update(User user ,out string errorMessage)
        {

            using (var context = new Context())
            {
                try
                {
                    var item = context.Users.SingleOrDefault(r => r.UserName == user.UserName);
                    errorMessage = "";
                    if (item == null) return false;
                    item.Name = user.Name;
                    item.Email = user.Email;
                    item.DateOfBirth = user.DateOfBirth;
                    item.Gender = user.Gender;
                    item.UserName = user.UserName;
                    item.Password = user.Password;
                    item.Role = user.Role;
                    item.Status = user.Status;
               

                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    return false;
                }

            }


        }




    }
}
