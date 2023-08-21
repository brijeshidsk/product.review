using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;

namespace RestFullWebAPI.Repositories
{
    public class UserRepository: IUserDataRepository<User>
    {
        private EComDBContext _db;

        public UserRepository(EComDBContext dBContext)
        {
            _db = dBContext;
        }
        public List<User> Get()
        {

            var users = _db.Users
                .Include("Addresses")
                .ToList();

            return users;

        }

        public User Get(int Id)
        {
            var user = _db.Users
                .Include("Addresses")
                .Where(c=>c.Id == Id).SingleOrDefault();

            return user;

        }


        public int Update(int id, User entity)
        {
            var user = _db.Users.Find(id);
            if(user == null)
            {
                throw new Exception($"User with Id {id} not found");
            }

            user.Firstname = entity.Firstname;
            user.Lastname = entity.Lastname;

            _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return id;

        }

        public int delete(int id)
        {

            var user = _db.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"User with Id {id} not found");
            }
            
            _db.Remove(user);
            _db.SaveChanges();
            return id;
        }

        public User create(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();

            return entity;
        }


        public User login(LoginParam entity)
        {
            var user = _db.Users.Where(c=>c.Email == entity.Email && c.Password==entity.Password).SingleOrDefault();
            return user;
        }
    }
}
