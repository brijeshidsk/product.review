using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestFullWebAPI.Repositories
{
    public interface IDataService<T>
    {
        List<T> Get();
        T Get(int id);
        T create (T entity);
        int Update (int id , T entity);
        int delete (int id);

    }
}
