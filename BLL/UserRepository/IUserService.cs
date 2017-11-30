using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserRepository
{
    public interface IUserService<T>
    {
        T GetByEmail(string email);
        List<T> GetAll();
        bool Add(T t);
        bool Update(T t);
        bool Remove(string userName);
        bool ValidUser(string email,string password);
    }
}
