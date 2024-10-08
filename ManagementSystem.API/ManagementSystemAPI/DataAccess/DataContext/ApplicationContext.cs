using ManagementSystemAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemAPI.DataAccess.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

       public DbSet<Staff> Staffs { get; set; }
       public DbSet<Company> Companies { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<Appraisal> Appraisals { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Clockin> Clockin { get; set; }
        public DbSet<ClockOut> Clockout { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Staff" }, new Role { Id = 2, Name = "Admin" });
            modelBuilder.Entity<StaffRole>().HasKey(k => new { k.RoleId, k.StaffId });
            modelBuilder.Entity<StaffRole>().HasOne(b=>b.Staff).WithMany(bs=>bs.Roles).HasForeignKey(b=>b.StaffId);
            modelBuilder.Entity<StaffRole>().HasOne(b=>b.Role).WithMany(bs=>bs.Staffs).HasForeignKey(b=>b.RoleId);

            
        }



    }
}
