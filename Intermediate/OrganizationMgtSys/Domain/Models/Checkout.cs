using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models
{
    public class Checkout : GenericProps
    {
        [ForeignKey(nameof(Staff))]
        public Guid StaffId { get; set; }
        public TimeSpan CheckoutTime { get; set; } 
        public string status { get; set; }

    }
}
