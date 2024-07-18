using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMgtSys.Domain.Models
{
    public class Address :GenericProps
    {
     
        [Required]
        [DataType(DataType.Text), Length(0, 20),]
        public string StreetName { get; set; } = "street";
        public string State { get; set; } = "State";
       // [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } = "Postal code";
        public string Country { get; set; } = "Country";
    }
}