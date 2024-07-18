using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models.Generic_Model
{
    public interface CompanyId
    {
     
        public Guid? CompanyID { get; set; }
    }
}
