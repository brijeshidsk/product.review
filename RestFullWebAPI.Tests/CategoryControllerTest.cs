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
    public class CategoryControllerTest
    {

        [Fact]
        public void GetCategoriesListTest()
        {
            //Arrange
            var mockService = new Mock<IDataService<Category>>();
            var mockLogger = new Mock<ILogger<CategoriesController>>();

            CategoriesController Controller = new CategoriesController(mockService.Object, mockLogger.Object);
 
            var categories = TestDataCategory.GetTestCategories();

            mockService.Setup(service => service.Get()).Returns(categories);

            //Act
            var result = Controller.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);

        }
        [Fact]
        public void GetCategoryByIdTest()
        {
            //Arrange
            var mockService = new Mock<IDataService<Category>>();
            var mockLogger = new Mock<ILogger<CategoriesController>>();

            CategoriesController Controller = new CategoriesController(mockService.Object, mockLogger.Object);

            var category = TestDataCategory.GetTestCategoryById();

            mockService.Setup(service => service.Get(It.IsAny<int>())).Returns(category);

            //Act
            var result = Controller.Get(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);

        }

    }
    // Helper methods for test data
    public static class TestDataCategory
    {
        public static List<Category> GetTestCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Electronics", Image = "/images/airpods.jpg"},
                new Category { Id = 2, Name = "Men's Fashion", Image = "/images/airpods.jpg"},
                new Category { Id = 3, Name = "Women's Fashion", Image = "/images/airpods.jpg"},

            };
        }

        public static Category GetTestCategoryById()
        {
            return new Category { Id = 1, Name = "Electronics", Image = "/images/airpods.jpg" };
        }

    }
}