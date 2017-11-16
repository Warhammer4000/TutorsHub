using System.Collections.Generic;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class UserRepo<T> where T : User
    {
        public T GetByName(string userName)
        {
            return new UserContext<T>().GetByName(userName);
        }

        public List<T> GetAll()
        {
            return new UserContext<T>().GetAll();
        }

        public bool Add(T t)
        {
            return new UserContext<T>().Add(t);
        }

        public bool Update(T t)
        {
            return new UserContext<T>().Update(t);
        }

        public bool Remove(string userName)
        {
            return new UserContext<T>().Remove(userName);
        }
    
}
}
