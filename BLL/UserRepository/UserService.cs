using System.Collections.Generic;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class UserService<T> where T : User
    {
        public T GetByEmail(string email)
        {
            return new UserRepository<T>().GetByEmail(email);
        }

        public List<T> GetAll()
        {
            return new UserRepository<T>().GetAll();
        }

        public bool Add(T t)
        {
            return new UserRepository<T>().Add(t);
        }

        public bool Update(T t)
        {
            return new UserRepository<T>().Update(t);
        }

        public bool Remove(string userName)
        {
            return new UserRepository<T>().Remove(userName);
        }

        public bool ValidUser(string email, string password)
        {
            User user= new UserRepository<T>().GetByEmail(email);
            if (user != null)
            {
                return user.Password == password;
            }
            return false;
           
           
        }



}
}
