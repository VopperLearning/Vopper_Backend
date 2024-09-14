
using Microsoft.EntityFrameworkCore;
using User_core.Entities;

namespace User_infrastructure.Persistence
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.User_Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.First_Name).HasMaxLength(75);
                entity.Property(e => e.Last_Name).HasMaxLength(85);
                entity.Property(e => e.Email).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(80).IsRequired();
                entity.Property(e => e.Verificate).IsRequired();
            });
        }
    }
}
