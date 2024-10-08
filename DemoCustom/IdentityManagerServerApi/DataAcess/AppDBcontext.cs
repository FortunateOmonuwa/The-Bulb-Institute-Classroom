using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManagerServerApi.DataAcess
{
  public class AppDBcontext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {
    }
}
