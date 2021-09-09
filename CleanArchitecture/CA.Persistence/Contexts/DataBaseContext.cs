using CA.Application.Interfaces.Contexts;
using CA.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CA.Persistence.Contexts
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
