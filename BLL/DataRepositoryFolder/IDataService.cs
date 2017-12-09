using System.Collections.Generic;

namespace BLL.DataRepositoryFolder
{
    public interface IDataService<T>
    {
        List<T> GetAll();
        bool Add(T t);
    }
}
