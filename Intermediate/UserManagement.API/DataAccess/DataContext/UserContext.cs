using Microsoft.EntityFrameworkCore;
using UserManagement.API.Domain;

namespace UserManagement.API.DataAccess.DataContext
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "User"}, new Role { Id = 2, Name = "Admin"});
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.RoleID, k.UserID });
            modelBuilder.Entity<UserRole>().HasOne(u => u.User).WithMany(ur => ur.UserRoles).HasForeignKey(u => u.UserID);
            modelBuilder.Entity<UserRole>().HasOne(u => u.Role).WithMany(ur => ur.UserRoles).HasForeignKey(u => u.RoleID);
        }
    }
}
