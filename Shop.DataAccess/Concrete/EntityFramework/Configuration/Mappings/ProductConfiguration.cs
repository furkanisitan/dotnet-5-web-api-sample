using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Name).IsUnique();

            // foreign key
            // Category(1) -> Product(n)
            builder.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id).HasColumnName("ProductId");
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(x => x.UnitsInStock);
            builder.Property(x => x.UnitPrice);
        }
    }
}
