using System.Collections.Generic;
using DLL.DataContext;
using Entity.Data;


namespace BLL.DataRepositoryFolder
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
        
        public bool Delete(T t)
        {
            return new DataRepository<T>().Delete(t);
        }

    }
}
