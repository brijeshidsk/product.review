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
    public class UserControllerTest
    {

        [Fact]
        public void GetUsersListTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);
 
            var users = TestData.GetTestUsers();

            mockService.Setup(service => service.Get()).Returns(users);

            //Act
            var result = Controller.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);

        }
        [Fact]
        public void GetUserByIdTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);

            var user = TestData.GetTestUserById();

            mockService.Setup(service => service.Get(It.IsAny<int>())).Returns(user);

            //Act
            var result = Controller.Get(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);

        }
        [Fact]
        public void CreateUserTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);

            var newUser = new User
            {
               Id = 10, Firstname = "Rakesh", Lastname = "Nagar", Role = User.userRole.User, Email = "Rakesh.Nagar@gmail.com", Password = "Password" 
            };

            mockService.Setup(service => service.Get()).Returns(new List<User>());
            mockService.Setup(service => service.create(It.IsAny<User>())).Returns(newUser);

            //Act
            var result = Controller.Post(newUser);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);

        }
        [Fact]
        public void UpdateUserTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);

            var updateUser = new User
            {
                Id = 10,
                Firstname = "Rakesh",
                Lastname = "Nagar",
                Role = User.userRole.User,
                Email = "Rakesh.Nagar@gmail.com",
                Password = "Password"
            };
            var user = TestData.GetTestUserById();


            mockService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<User>())).Returns(200);

            //Act
            var result = Controller.Put(updateUser.Id, updateUser);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void DeleteUserTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);



            mockService.Setup(service => service.delete(It.IsAny<int>())).Returns(200);

            //Act
            var result = Controller.Delete(10);
            //Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void LoginUserTest()
        {
            //Arrange
            var mockService = new Mock<IUserDataService<User>>();
            var mockLogger = new Mock<ILogger<UsersController>>();

            UsersController Controller = new UsersController(mockService.Object, mockLogger.Object);

            var user = TestData.LoginTestUser();

            mockService.Setup(service => service.login(It.IsAny<LoginParam>())).Returns(user);

            var loginUser = new LoginParam
            {
                Email = "Rakesh.Nagar@gmail.com",
                Password = "Password",
            };
            //Act
            var result = Controller.Login(loginUser);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
    // Helper methods for test data
    public static class TestData
    {
        public static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Firstname = "John1", Lastname = "Smith1", Role = User.userRole.Admin, Email = "John.Smith@gmail.com", Password = "Password" },
                new User { Id = 2, Firstname = "Sachin", Lastname = "Kumar", Role = User.userRole.User, Email = "Sachin.Kumar@gmail.com", Password = "Password" },
               
            };
        }

        public static User GetTestUserById()
        {
            return new User { Id = 1, Firstname = "John1", Lastname = "Smith1", Role = User.userRole.Admin, Email = "John.Smith@gmail.com", Password = "Password" };
               
        }

        public static User CreateTestUser()
        {
            return new User { Id = 10, Firstname = "Rakesh", Lastname = "Nagar", Role = User.userRole.User, Email = "Rakesh.Nagar@gmail.com", Password = "Password" };

        }

        public static User LoginTestUser()
        {
            return new User { Id = 10, Firstname = "Rakesh", Lastname = "Nagar", Role = User.userRole.User, Email = "Rakesh.Nagar@gmail.com", Password = "Password" };

        }

    }
}