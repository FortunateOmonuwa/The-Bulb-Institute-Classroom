using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Domain.Models
{
    public class Query
    {
        [Key]
        public Guid ID { get; set; }
        [Required,ForeignKey(nameof(Staff))]
        public Guid StaffID { get; set; }
        public string Message { get; set; } = "";
    }
}
