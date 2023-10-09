using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace users_api.DAL.EF.EntityTypeConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => ur.Id);
            builder.Property(ur => ur.Id).ValueGeneratedOnAdd();

            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.RoleId);

            builder.HasOne(ur => ur.User)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasData(
                new UserRole()
                {
                    Id = 111,
                    UserId = 11,
                    RoleId = 2
                },
                new UserRole()
                {
                    Id = 112,
                    UserId = 11,
                    RoleId = 3
                },
                new UserRole()
                {
                    Id = 113,
                    UserId = 12,
                    RoleId = 1
                },
                new UserRole()
                {
                    Id = 114,
                    UserId = 13,
                    RoleId = 4
                },
                new UserRole()
                {
                    Id = 115,
                    UserId = 14,
                    RoleId = 1
                },
                new UserRole()
                {
                    Id = 116,
                    UserId = 14,
                    RoleId = 3
                }
            );
        }
    }
}
