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
        T GetWithTutors(string subjectName);
        bool Add(T t);
        bool Update(T t);
        bool Delete(T t);


    }
}
