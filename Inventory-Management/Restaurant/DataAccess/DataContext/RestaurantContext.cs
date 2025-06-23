using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Category;
using Restaurant.Models.Chows;
using Restaurant.Models.User;

namespace Restaurant.DataAccess.DataContext
{
    public class RestaurantContext :IdentityDbContext<User>
    {
        public RestaurantContext(DbContextOptions options) : base(options) { }



       public DbSet<Chows> Chows { get; set; }
       public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses {  get; set; } 
        public new DbSet<User>  Users {  get; set; } 

    }
}
