using System.Net;
using Microsoft.EntityFrameworkCore;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;
using static Unity.Storage.RegistrationSet;

namespace RestFullWebAPI.Repositories
{
    public class ProductRepository:IProductDataRepository<Product>
    {
        private EComDBContext _db;

        public ProductRepository(EComDBContext dBContext)
        {
            _db = dBContext;
        }

        public int create(Product entity)
        {
            _db.Add(entity);
            _db.SaveChanges();

            return entity.Id;
        }

        public void delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                throw new Exception($"Product with Id {id} not found");
            }

            _db.Remove(product);
            _db.SaveChanges();
        }

        public List<Product> Get()
        {
            var products = _db.Products.Include("Reviews").Take(10).ToList();
            return products;
        }

        public Product Get(int id)
        {
            var product = _db.Products
                          .Include("Reviews")
                          .Where(c => c.Id == id).SingleOrDefault();

            return product;
        }

        public List<Product> getProductsByCategoryId(int categoryId)
        {

            var products = _db.Products.Include("Reviews")
                .Where(p=>p.CategoryId == categoryId)
                .ToList();

            return products;

        }

        public Product reviews(Review review)
        {
            var product = _db.Products.Find(review.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with Id {review.ProductId} not found");
            }

            _db.Reviews.Add(review);
            _db.SaveChanges();

            product.Rating = product.Rating + review.Rating;
            product.NumReviews = product.NumReviews + 1;

            _db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();


            return product;

        }

        public void Update(int id, Product entity)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                throw new Exception($"Product with Id {id} not found");
            }

            product.ProductName = entity.ProductName;
            product.UnitPrice = entity.UnitPrice;
            product.Brand = entity.Brand;
            product.Description = entity.Description;
            product.SellerName = entity.SellerName;
            product.SellerContact = entity.SellerContact;
            product.SellerEmail = entity.SellerEmail;
            product.Image = entity.Image;
            product.CategoryId = entity.CategoryId;
            product.UnitsInStock = entity.UnitsInStock;


            _db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
