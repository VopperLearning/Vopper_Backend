
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_core.Entities;

namespace User_infrastructure.Persistence
{
    public class UserDBContext : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
                builder.Property(e => e.User_Name).HasMaxLength(50).IsRequired();
                builder.Property(e => e.First_Name).HasMaxLength(75);
                builder.Property(e => e.Last_Name).HasMaxLength(85);
                builder.Property(e => e.Email).HasMaxLength(150).IsRequired();
                builder.Property(e => e.Password).HasMaxLength(80).IsRequired();
                builder.Property(e => e.Verificate).IsRequired();
        }
    }
}
