using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.DataContext;
using Entity.Data;

namespace BLL.DataRepository
{
    public abstract class DataService<T> where T:DataModel
    {
        public List<T> GetAll()
        {
            return new DataRepository<T>().GetAll();
        }

        public bool Add(T t)
        {
            return new DataRepository<T>().Add(t);
        }

    }
}
