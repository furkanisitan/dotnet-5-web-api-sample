using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializers
{
    class DbInitializer : IDbInitializer
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public DbInitializer()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            #region CategorySeed

            var categories = new List<Category>
            {
                new () { Id = 1, Name = "Phone" },
                new () { Id = 2, Name = "Computer" },
                new () { Id = 3, Name = "Home & Kitchen" }
            };
            modelBuilder.Entity<Category>().HasData(categories);
            #endregion

            #region ProductSeed

            var products = new List<Product>
            {
                new () { Id = 1, Name = "Vestel Venus", CategoryId = 1, UnitPrice = 3600, UnitsInStock = 145 },
                new () { Id = 2, Name = "General Mobile", CategoryId = 1, UnitPrice = 3258, UnitsInStock = 101 },
                new () { Id = 3, Name = "Casper Via", CategoryId = 1, UnitPrice = 3542, UnitsInStock = 74 },
                new () { Id = 4, Name = "Casper Nirvana", CategoryId = 2, UnitPrice = 7980, UnitsInStock = 129 },
                new () { Id = 5, Name = "Hometech Alfa", CategoryId = 2, UnitPrice = 6870, UnitsInStock = 187 },
                new () { Id = 6, Name = "Beko", CategoryId = 3, UnitPrice = 142, UnitsInStock = 389 },
                new () { Id = 7, Name = "Arçelik", CategoryId = 3, UnitPrice = 167, UnitsInStock = 307 },
                new () { Id = 8, Name = "Simfer", CategoryId = 3, UnitPrice = 89, UnitsInStock = 578 },
            };
            modelBuilder.Entity<Product>().HasData(products);
            #endregion

            #region UserSeed

            var users = new List<User>
            {
                new () { Id = 1, UserName = "admin", Email = "admin@gmail.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")},
                new () { Id = 2, UserName = "user", Email = "user@gmail.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")},
                new () { Id = 3, UserName = "employee", Email = "employee@gmail.com",  PasswordHash = _passwordHasher.HashPassword(null,"1234")}
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region RoleSeed

            var roles = new List<Role>
            {
                new () { Id = 1, Name = "admin" },
                new () { Id = 2, Name = "user" },
                new () { Id = 3, Name = "employee" }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region UserRoleSeed

            var userRoles = new List<UserRole>
            {
                new () { UserId = 1, RoleId = 1 },
                new () { UserId = 1, RoleId = 2 },
                new () { UserId = 2, RoleId = 2 },
                new () { UserId = 3, RoleId = 3 }
            };
            modelBuilder.Entity<UserRole>().HasData(userRoles);
            #endregion
        }
    }
}
