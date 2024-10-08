using bankingClassAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace bankingClassAPI.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }  
            
        
    }
}
