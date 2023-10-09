using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace users_api.DAL.EF.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(u => u.Roles)
                   .WithMany(r => r.Users)
                   .UsingEntity<UserRole>();

            builder.HasData(
                new User()
                {
                    Id = 11,
                    Name = "Vladislav",
                    Age = 20,
                    Email = "vladislav@gmail.com"
                },
                new User()
                {
                    Id = 12,
                    Name = "Ivan",
                    Age = 21,
                    Email = "ivan@gmail.com"
                },
                new User()
                {
                    Id = 13,
                    Name = "Aleksandr",
                    Age = 22,
                    Email = "aleksandr@gmail.com"
                },
                new User()
                {
                    Id = 14,
                    Name = "name",
                    Age = 35,
                    Email = "name@gmail.com"
                }
            );
        }
    }
}
