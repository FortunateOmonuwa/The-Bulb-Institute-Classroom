using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.User
{
    public class User : IdentityUser

    {
     public Address Address { get; set; }   
    }
}
