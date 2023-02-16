using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;


namespace UserManagement.Infrastructure.Context
{
    public class UserManagementContext : IdentityDbContext<UserEntity>
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is already configured on the Startup.cs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //new ApplicationUserEntityTypeConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());


        }

    }
}
