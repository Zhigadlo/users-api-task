using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using users_api.DAL.Models;

namespace users_api.DAL.EF.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Age);
            builder.Property(x => x.Email);
            builder.Property(x => x.Role);
            builder.HasData(
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vladislav",
                    Age = 20,
                    Email = "vladislav@gmail.com",
                    Role = Role.User
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ivan",
                    Age = 21,
                    Email = "ivan@gmail.com",
                    Role = Role.Support
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Aleksandr",
                    Age = 22,
                    Email = "aleksandr@gmail.com",
                    Role = Role.SuperAdmin
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Age = 35,
                    Email = "admin@gmail.com",
                    Role = Role.Admin
                }
            );
        }
    }
}
