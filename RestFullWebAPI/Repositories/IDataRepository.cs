using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFullWebAPI.Repositories
{
    public interface IDataRepository<T>
    {
        List<T> Get();
        T Get(int id);
        int create (T entity);
        void Update (int id , T entity);
        void delete (int id);

    }
}
