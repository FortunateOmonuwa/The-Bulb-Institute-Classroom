using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrganizationMgtSys.Domain.Models
{
    public class CheckIn : GenericProps
    {
        [ForeignKey(nameof(Staff))]
        public Guid StaffId { get; set; }
        public TimeSpan CheckinTime { get; set; }
        public string status { get; set; }
    }
}
