using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Services;

namespace RestFullWebAPI.Tests.Repositories
{
    public class TestUserRepository : IUserDataService<User>    
    {
        List<User> _users = new List<User> {
                new User { Id = 1, Firstname = "John", Lastname = "Smith" },
                new User { Id = 2, Firstname = "Sachin", Lastname = "Kumar" }

        };

        public User create(User entity)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User login(LoginParam loginParam)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
