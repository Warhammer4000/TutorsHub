using System.Collections.Generic;

namespace BLL.DataRepositoryFolder
{
    public interface IDataService<T>
    {
        List<T> GetAll();
        T GetWitId(int id);
        bool Add(T t);
        bool Delete(int id);
    }
}
