using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;

namespace RestFullWebAPI.Repositories
{
    public interface IProductDataRepository<T> : IDataRepository<T>
    {
        T reviews(Review review);

    }
}
