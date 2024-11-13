using Auth_Module.Auth_Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Auth_Module.Auth_Infraestructure.Persistence.Configurations;
using Pomelo.EntityFrameworkCore.MySql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;

namespace Auth_Module.Auth_Infraestructure.Persistence
{
    public class AuthModelDbContext : DbContext
    {
        public AuthModelDbContext(DbContextOptions<AuthModelDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "Server=db;Database=vopper_db;User=vopper_user;Password=userpassword;";
             var connectionString  = "host=dpg-csp6vua3esus739fmd6g-a;port=5432;Database=vopper_db;Username=vopper_user;password=kLPXW1TsPgvcgm5CNsSKM8DbzhBN5TXY";
           // optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
           optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Auth_User> Auth_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new User_Configuration());
        }
    }
}