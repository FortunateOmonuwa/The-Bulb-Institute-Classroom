using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models
{
    public class Role 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
  
    }
}
