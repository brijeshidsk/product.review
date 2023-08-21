using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Models;
using System.Net;
using RestFullWebAPI.Models.DTO;

namespace RestFullWebAPI.Services
{
    public class UserService: IUserDataService<User>
    {
        IUserDataRepository<User> _repo;
        public UserService(IUserDataRepository<User> repo)
        {
            _repo = repo;
        }
       
        public List<User> Get()
        {
            var users = _repo.Get();

            return users;
        }

        public User Get(int Id)
        {
            var user = _repo.Get(Id);

            return user;
        }

        public int Update(int id , User user)
        {
            _repo.Update(id ,user);

            return id;
        }

        public int delete(int id)
        {
            _repo.delete(id);
            return id;
        }

        public User create(User entity)
        {
            _repo.create(entity);

            return entity;
        }

        public User login(LoginParam entity)
        {
            var user = _repo.login(entity);

            return user;
        }
    }
}
