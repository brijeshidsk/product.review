using RestFullWebAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace RestFullWebAPI.Models
{
    public class EComDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Review> Reviews { get; set; }


        public EComDBContext(DbContextOptions<EComDBContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //Seed Data
            //Add-Migration
            //Update-Database
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                Email = "John.Smith@gmail.com",
                Password = "Password",
                Role = User.userRole.Admin,

            });
            modelBuilder.Entity<Address>().HasData(
           new Address
           {
               Id = 1,
               UserId = 1,
               AddressLine1 = "Adil",
               AddressLine2 = "nagar",
               City = "lko"
           });
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 2,
                Firstname = "Sachin",
                Lastname = "Kumar",
                Email = "Sachin.Kumar@gmail.com",
                Password = "Password",
                Role = User.userRole.User,

            });
            modelBuilder.Entity<Address>().HasData(
           new Address
           {
               Id = 2,
               UserId = 2,
               AddressLine1 = "Andheri",
               AddressLine2 = "new",
               City = "Mumbai"
           });
            modelBuilder.Entity<Category>().HasData(
           new Category
           {
               Id = 1,
               Name = "Electronics",
               Image = "",
           },
           new Category
           {
               Id = 2,
               Name = "Men's Fashion",
               Image = "",
           },
           new Category
           {
               Id = 3,
               Name = "Women's Fashion",
               Image = "",
           },
           new Category
           {
               Id = 4,
               Name = "Home Kitchen",
               Image = "",
           },
           new Category
           {
               Id = 5,
               Name = "Toys",
               Image = "",
           }
           );
            // modelBuilder.Entity<Product>().HasData(
            //     new Product
            //     {

            //     }
            //     );

            // modelBuilder.Entity<OrderDetails>()
            //   .HasKey(table => new
            //   {
            //       table.OrderId,
            //       table.ProductId
            //   });
        }


    }
}
