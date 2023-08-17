using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;
using RestFullWebAPI.Repositories;
using static Unity.Storage.RegistrationSet;

namespace RestFullWebAPI.Services
{
    public class ProductService: IProductDataService<Product>
    {
        IProductDataRepository<Product> _repo;
        public ProductService(IProductDataRepository<Product> repo)
        {
            _repo = repo;
        }

        public int create(Product entity)
        {
            _repo.create(entity);
            return entity.Id;
        }

        public List<Product> Get()
        {
            var products = _repo.Get();
            return products;
        }

        public Product Get(int id)
        {
            var product = _repo.Get(id);
            return product;
        }

        //public List<Product> getProductsByCategoryId(int categoryId)
        //{
        //    var products = _repo.getProductsByCategoryId(categoryId);

        //    return products;
        //}

        public void Update(int id, Product entity)
        {
            _repo.Update(id, entity);
        }
        public void delete(int id)
        {
            _repo.delete(id);
        }

        public Product reviews(Review review)
        {
            var product = _repo.reviews(review);
            return product;
        }
    }
}
