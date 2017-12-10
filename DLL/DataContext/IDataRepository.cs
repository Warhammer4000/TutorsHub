using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DataContext
{
    interface  IDataRepository<T>
    {
        List<T> GetAll();

        bool Add(T t);
        bool Update(T t);
        bool Delete(T t);


    }
}
