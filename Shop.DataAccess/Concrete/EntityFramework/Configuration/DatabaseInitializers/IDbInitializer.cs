using Microsoft.EntityFrameworkCore;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializers
{
    interface IDbInitializer
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
