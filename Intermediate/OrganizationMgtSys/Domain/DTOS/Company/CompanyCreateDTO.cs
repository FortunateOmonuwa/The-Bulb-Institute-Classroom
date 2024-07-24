using OrganizationMgtSys.Domain.DTOS.AddressDTO;
using OrganizationMgtSys.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.DTOS.Company
{
    public class CompanyCreateDTO
    {
        public string Name { get; set; }

        public AddressCreateDTO Address { get; set; }
        public string Abbreviation { get; set; }
        //public TimeSpan? StandardCheckinTime { get; set; } 
        //public TimeSpan? StandardCheckOutTime { get; set; }
    }
}
