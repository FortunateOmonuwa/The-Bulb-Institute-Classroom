using Microsoft.EntityFrameworkCore;
using UserManagementApi.Domain;

namespace UserManagementApi.DataAccess.DataContext
{
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1 , Name = "User"}, new Role {Id = 2, Name ="Admin" });
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.RoleID, k.UserID });
            modelBuilder.Entity<UserRole>().HasOne(c => c.User).WithMany(cs => cs.Roles).HasForeignKey(c => c.UserID);
            modelBuilder.Entity<UserRole>().HasOne(c => c.Role).WithMany(cs => cs.Users).HasForeignKey(c => c.RoleID);
        }

    }
}
