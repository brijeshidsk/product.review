using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFullWebAPI.Models;

namespace RestFullWebAPI.Repositories
{
    public class CategoryRepository : IDataRepository<Category>
    {
        private EComDBContext _db;

        public CategoryRepository(EComDBContext dBContext)
        {
            _db = dBContext;
        }

        public Category create(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {

            var categories = _db.Categories
                .ToList();

            return categories;

        }

        public Category Get(int id)
        {
            var category = _db.Categories
                          .Where(c => c.Id == id).SingleOrDefault();

            return category;
        }

        public int Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
