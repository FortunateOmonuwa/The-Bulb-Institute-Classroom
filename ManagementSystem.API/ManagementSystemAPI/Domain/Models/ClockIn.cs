using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ManagementSystemAPI.Domain.Models
{
    public class Clockin
    {
        [Key]
        public Guid ID { get; set; }
        [Required, ForeignKey(nameof(Staff))]
        public Guid StaffID { get; set; }
        
        public string CheckInTime { get; set; } = DateTime.Now.ToString("G");
        
        public string Message { get; set; } = "";
    }
}
