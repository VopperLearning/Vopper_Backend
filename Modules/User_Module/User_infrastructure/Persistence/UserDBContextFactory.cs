using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using User_core.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace User_infrastructure.Persistence
{
    public class UserDBContextFactory : DbContext 
    {
       public UserDBContextFactory(DbContextOptions<UserDBContextFactory> options) : base(options)
       {
       }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* var connectionString = "Server=db;Database=vopper_db;User=vopper_user;Password=userpassword;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));*/
            var connectionString = "host=localhost;port=5433;Database=vopper;Username=postgres;password=root";
             //var connectionString  = "host=dpg-csp6vua3esus739fmd6g-a;port=5432;Database=vopper_db;Username=vopper_user;password=kLPXW1TsPgvcgm5CNsSKM8DbzhBN5TXY";
             optionsBuilder.UseNpgsql(connectionString);
        }

         public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserDBContext());
        }

       
    }
}
