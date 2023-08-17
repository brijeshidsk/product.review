using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestFullWebAPI.Models.DTO;

namespace RestFullWebAPI.Repositories
{
    public interface IUserDataService<T> : IDataRepository<T>
    {
        T login(LoginParam loginParam);

    }
}
