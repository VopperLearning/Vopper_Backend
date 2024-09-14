using Microsoft.EntityFrameworkCore;
using User_Module.User_core.Entities;

namespace User_Module.User_infraestructure.Persistence
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //TODO: Add more entities
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
    }
}
