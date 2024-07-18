using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models
{
    public class Query : GenericProps
    {
        [ForeignKey(nameof(Staff))]
        public Guid StaffId { get; set; }
        public string Message { get; set; }
    }
}