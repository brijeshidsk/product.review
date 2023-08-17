using RestFullWebAPI.Models;
using RestFullWebAPI.Repositories;

namespace RestFullWebAPI.Services
{
    public class CategoryService: IDataService<Category>
    {
        IDataRepository<Category> _repo;
        public CategoryService(IDataRepository<Category> repo)
        {
            _repo = repo;
        }

        public int create(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            var categories = _repo.Get();

            return categories;
        }

        public Category Get(int id)
        {
            var category = _repo.Get(id);

            return category;
        }

        public void Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
