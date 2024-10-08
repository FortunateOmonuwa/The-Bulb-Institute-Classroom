using System.ComponentModel.DataAnnotations;

namespace ManagementSystemAPI.Domain.Models
{
    public class Address
    {
        [Key]
        public Guid ID { get; set; }
        [Required,DataType(DataType.Text),Length(0,20)]
        public string StreetName { get; set; } = "street";
        [Required]
        public string State { get; set; } = "state";
        [Required]
        public string PostalCode { get; set; } = "Postal Code";
        [Required]
        public string Country { get; set; } = "Country";
    }
}
