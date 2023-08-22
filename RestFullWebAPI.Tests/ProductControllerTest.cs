using RestFullWebAPI.Controllers;
using Microsoft.Extensions.Logging;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using RestFullWebAPI.Models.DTO;

namespace RestFullWebAPI.Tests
{
    public class ProductControllerTest
    {

        [Fact]
        public void GetProductsListTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);
 
            var products = TestDataProduct.GetTestProducts();

            mockService.Setup(service => service.Get()).Returns(products);

            //Act
            var result = Controller.Get();

            //Assert
            var okResult = Assert.IsType<List<Product>>(result);
            Assert.NotNull(result);
            Assert.Equal(products.Count(), result.Count());

        }
        [Fact]
        public void GetProductByIdTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);

            var product = TestDataProduct.GetTestProductById();

            mockService.Setup(service => service.Get(It.IsAny<int>())).Returns(product);

            //Act
            var result = Controller.Get(1);

            //Assert
            var okResult = Assert.IsType<Product>(result);
            Assert.NotNull(result);
            Assert.Equal(product.ProductName, result.ProductName);

        }
        [Fact]
        public void CreateProductTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);

            var newProduct = new Product { Id = 1, CategoryId = 5, ProductName = "Airpod", UnitPrice = 10, UnitsInStock = 10, Image = "/images/airpods.jpg", Brand = "Boat", Description = "Boat", SellerContact = "8090018733", SellerEmail = "brijesh@gmail.com", SellerName = "brijesh", NumReviews = 6, Rating = 7 };


            mockService.Setup(service => service.create(It.IsAny<Product>())).Returns(newProduct);

            //Act
            var result = Controller.Post(newProduct);

            //Assert
            var okResult = Assert.IsType<Product>(result);
            Assert.NotNull(result);
            Assert.Equal(newProduct.ProductName, result.ProductName);

        }
        [Fact]
        public void UpdateProductTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);

            var updateProduct = new Product { Id = 1, CategoryId = 5, ProductName = "Airpod", UnitPrice = 10, UnitsInStock = 10, Image = "/images/airpods.jpg", Brand = "Boat", Description = "Boat", SellerContact = "8090018733", SellerEmail = "brijesh@gmail.com", SellerName = "brijesh", NumReviews = 6, Rating = 7 };


            mockService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Product>())).Returns(200);

            //Act
            var result = Controller.Put(updateProduct.Id, updateProduct);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void DeleteProductTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);

            mockService.Setup(service => service.delete(It.IsAny<int>())).Returns(200);

            //Act
            var result = Controller.Delete(1);
            //Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void ReviewProductTest()
        {
            //Arrange
            var mockService = new Mock<IProductDataService<Product>>();
            var mockLogger = new Mock<ILogger<ProductsController>>();

            ProductsController Controller = new ProductsController(mockService.Object, mockLogger.Object);

            var reviewProduct = new Review
            {
                Id = 1,
                ProductId = 1,
                UserId = 2,
                Rating = 2,
                Comments = "Good",

            };
            var product = new Product { Id = 1, CategoryId = 5, ProductName = "Airpod", UnitPrice = 10, UnitsInStock = 10, Image = "/images/airpods.jpg", Brand = "Boat", Description = "Boat", SellerContact = "8090018733", SellerEmail = "brijesh@gmail.com", SellerName = "brijesh", NumReviews = 6, Rating = 7 };

            mockService.Setup(service => service.reviews(It.IsAny<Review>())).Returns(product);

         
            //Act
            var result = Controller.Reviews(reviewProduct);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
    // Helper methods for test data
    public static class TestDataProduct
    {
        public static List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, CategoryId = 5, ProductName = "Airpod", UnitPrice = 10, UnitsInStock = 10, Image = "/images/airpods.jpg",Brand="Boat",Description="Boat", SellerContact="8090018733",SellerEmail="brijesh@gmail.com", SellerName="brijesh", NumReviews=6, Rating=7 },
                new Product { Id = 2, CategoryId = 1, ProductName = "Alexa", UnitPrice = 100, UnitsInStock = 0, Image = "/images/alexa.jpg",Brand="Amazon",Description="Amazon", SellerContact="12345678",SellerEmail="deepak@gmail.com", SellerName="Deepak", NumReviews=3, Rating=4 },
                new Product { Id = 3, CategoryId = 1, ProductName = "Camera", UnitPrice = 3000, UnitsInStock = 1, Image = "/images/camera.jpg",Brand="Sansui",Description="Sansui", SellerContact="797898989",SellerEmail="rakesh@gmail.com", SellerName="rakesh", NumReviews=5, Rating=7 },

            };
        }

        public static Product GetTestProductById()
        {
            return new Product { Id = 1, CategoryId = 5, ProductName = "Airpod", UnitPrice = 10, UnitsInStock = 10, Image = "/images/airpods.jpg", Brand = "Boat", Description = "Boat", SellerContact = "8090018733", SellerEmail = "brijesh@gmail.com", SellerName = "brijesh", NumReviews = 6, Rating = 7 };
        }

    }
}