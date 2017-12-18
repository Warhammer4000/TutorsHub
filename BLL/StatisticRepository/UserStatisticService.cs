using System.Collections.Generic;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.StatisticRepository
{
    public class UserStatisticService<T> where T:User
    {

        private List<T> GetUsers()
        {
            return new UserRepository<T>().GetAll();
        }

        public int GetCount()
        {
            return new UserRepository<T>().GetAll().Count;
        }



    }
}
