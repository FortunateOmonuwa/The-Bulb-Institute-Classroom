using InventoryManagementAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.DataAccess.DataContext
{
    public class ApplicationContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Staff" }, new Role { Id = 3, Name = "Customer" });
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.RoleID, k.UserID });
            modelBuilder.Entity<UserRole>().HasOne(h => h.User).WithMany(cs => cs.Roles).HasForeignKey(c => c.UserID);
            modelBuilder.Entity<UserRole>().HasOne(h => h.Role).WithMany(cs => cs.Users).HasForeignKey(c => c.RoleID);


        }
    }
}
