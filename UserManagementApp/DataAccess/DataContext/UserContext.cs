using Microsoft.EntityFrameworkCore;
using UserManagementApp.Domain.Model;

namespace UserManagementApp.DataAccess.DataContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options): base(options) { }
        
        public DbSet<User> Users {  get; set; }    
        
    }
}
