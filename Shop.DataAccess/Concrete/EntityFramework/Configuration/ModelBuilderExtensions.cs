using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializers;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration
{
    static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            new DbInitializer().Seed(modelBuilder);
        }
    }
}
