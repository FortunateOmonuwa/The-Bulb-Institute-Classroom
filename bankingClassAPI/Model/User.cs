using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace bankingClassAPI.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string AccountName { get; set; } = "";
        public string Email { get; set; } = "";
        [Required, Length(10, 10)]
        public string AccountNumber { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccountBalance { get; set; } = 0;
    }
}
