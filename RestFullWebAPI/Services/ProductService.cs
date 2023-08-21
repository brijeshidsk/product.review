using Microsoft.AspNetCore.Mvc;
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

        public Product create(Product entity)
        {
            _repo.create(entity);
            return entity;
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

        public int Update(int id, Product entity)
        {
            _repo.Update(id, entity);
            return id;
        }
        public int delete(int id)
        {
            _repo.delete(id);
            return id;
        }

        public Product reviews(Review review)
        {
            var product = _repo.reviews(review);
            return product;
        }
    }
}
