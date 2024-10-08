
using Microsoft.AspNetCore.Identity;

namespace IdentityManagerServerApi.DataAcess
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }   
    }
}
