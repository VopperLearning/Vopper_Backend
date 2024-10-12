using Auth_Module.Auth_Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Auth_Module.Auth_Infraestructure.Persistence.Configurations
{
    public class User_Configuration : IEntityTypeConfiguration<Auth_User>
    {
        public void Configure(EntityTypeBuilder<Auth_User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.UserName)
            .IsUnique();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Roles).IsRequired();
        }
    }
}