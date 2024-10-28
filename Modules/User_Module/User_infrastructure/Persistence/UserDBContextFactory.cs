using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using User_core.Entities;

namespace User_infrastructure.Persistence
{
    public class UserDBContextFactory : DbContext 
    {
       public UserDBContextFactory(DbContextOptions<UserDBContextFactory> options) : base(options)
       {
       }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=VopperBD;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

         public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserDBContext());
        }

       
    }
}
