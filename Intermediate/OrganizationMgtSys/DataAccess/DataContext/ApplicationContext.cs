using Microsoft.EntityFrameworkCore;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.DataAccess.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Staff> Staff { get; set;}
        public DbSet<Role> Role { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appraisal> Appraisals { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<CheckIn> StaffCheckIns { get; set; }
        public DbSet<Checkout> StaffCheckOuts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>()
                .HasData(
                new Role { Id = 1, Name= "Admin"},
                new Role { Id = 2, Name= "Staff"}
                //new Role { Id = 3, Name= "Dispatch"}
                );
        }
    }
}
