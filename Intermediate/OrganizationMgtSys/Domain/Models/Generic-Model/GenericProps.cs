using System.ComponentModel.DataAnnotations;

namespace OrganizationMgtSys.Domain.Models.Generic_Model
{
    public class GenericProps
    {
        [Key]
        public Guid Id { get; set; }
    }
}
