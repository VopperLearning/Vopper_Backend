using Auth_Module.Auth_Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Auth_Module.Auth_Infraestructure.Persistence.Configurations;
using Pomelo.EntityFrameworkCore.MySql;
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
            var connectionString = "server=localhost;database=VopperBD;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Auth_User> Auth_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new User_Configuration());
        }
    }
}