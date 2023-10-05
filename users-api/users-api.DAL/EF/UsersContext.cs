using Microsoft.EntityFrameworkCore;
using users_api.DAL.EF.EntityTypeConfigurations;
using users_api.DAL.Models;

namespace users_api.DAL.EF
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
