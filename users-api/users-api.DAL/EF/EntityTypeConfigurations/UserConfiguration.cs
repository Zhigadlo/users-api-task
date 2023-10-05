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
        }
    }
}
