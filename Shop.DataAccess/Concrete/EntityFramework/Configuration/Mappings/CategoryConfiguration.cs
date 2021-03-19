using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Id).HasColumnName("CategoryId");
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
