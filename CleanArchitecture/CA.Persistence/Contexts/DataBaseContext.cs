using CA.Application.Interfaces.Contexts;
using CA.Common.Roles;
using CA.Domain.Entities.Category;
using CA.Domain.Entities.Product;
using CA.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CA.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            ApplyQueryFilter(modelBuilder);
        }


        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(new Role {Id = 1, Name = nameof(UserRolesNames.Admin)});
            modelBuilder.Entity<Role>().HasData(new Role {Id = 2, Name = nameof(UserRolesNames.Operator)});
            modelBuilder.Entity<Role>().HasData(new Role {Id = 3, Name = nameof(UserRolesNames.Customer)});
        }
    }
}
