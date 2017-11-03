using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.UserContext
{
    public interface IUserContext<T>
    {
        T GetByName(string userName);
        List<T> GetAll();
        bool Add(T t);
        bool Update(T t);
        bool Remove(string userName);

    }
}
