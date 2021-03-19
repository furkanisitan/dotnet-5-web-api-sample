using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.Mappings
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // primary key
            builder.HasKey(x => x.Id);
            // unique key 
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            // many-to-many (User -> Role)
            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRole>(
                    j => j.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                    j => j.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId),
                    j =>
                    {
                        j.ToTable("UserRoles");
                        j.HasKey(ur => new { ur.UserId, ur.RoleId });
                    });

            builder.Property(x => x.Id).HasColumnName("UserId");
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsRequired().HasColumnType("nvarchar(max)");
        }
    }
}
