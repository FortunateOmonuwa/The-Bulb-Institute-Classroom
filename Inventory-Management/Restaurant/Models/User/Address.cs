using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.User
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; } = "Heaven";
        public string City { get; set; } = "Lag";
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
