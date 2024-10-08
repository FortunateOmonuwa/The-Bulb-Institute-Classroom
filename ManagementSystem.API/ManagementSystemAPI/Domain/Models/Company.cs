using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ManagementSystemAPI.Domain.Models
{
    public class Company
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [ForeignKey(nameof(Address))]  
        public Guid AddressID {  get; set; }    
        public Address? Address { get; set; } 
        [Required]
        public string Abbreviation { get; set; } = "";

        public string StandardCheckinTime { get; set; } = new TimeSpan(9,0,0).ToString(@"hh\:mm\:ss");
        public string StandardCheckoutTime { get; set; } = new TimeSpan(17,0,0).ToString(@"hh\:mm\:ss");
        public List<Staff>? Staffs {  get; set; }

       
    }
}
