using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace users_api.DAL.EF.EntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired();

            builder.HasMany(r => r.Users)
                   .WithMany(r => r.Roles)
                   .UsingEntity<UserRole>();

            builder.HasData(
                new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Support"
                },
                new Role()
                {
                    Id = 4,
                    Name = "SuperAdmin"
                }
            );
        }
    }
}
