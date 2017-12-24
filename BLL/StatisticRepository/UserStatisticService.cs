using System.Collections.Generic;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.StatisticRepository
{
    public class UserStatisticService<T> where T:User
    {

        private List<T> GetUsers() => new UserRepository<T>().GetAll();

        public int GetCount() => new UserRepository<T>().GetAll().Count;



    }
}
