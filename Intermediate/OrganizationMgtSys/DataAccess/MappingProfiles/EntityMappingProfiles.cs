using AutoMapper;
using OrganizationMgtSys.Domain.DTOS.AddressDTO;
using OrganizationMgtSys.Domain.DTOS.Company;
using OrganizationMgtSys.Domain.DTOS.StaffDTO;
using OrganizationMgtSys.Domain.Models;

namespace OrganizationMgtSys.DataAccess.MappingProfiles
{
    public class EntityMappingProfiles : Profile
    {
        public EntityMappingProfiles() 
        {
            CreateMap<CompanyCreateDTO, Company>().ReverseMap();
            CreateMap<Company, CompanyGetDTO>().ReverseMap();
            CreateMap<AddressCreateDTO, Address>().ReverseMap();
            CreateMap<Address, AddressGetDTO>().ReverseMap();
            CreateMap<StaffCreateDTO, Staff>().ReverseMap();
            CreateMap<Staff, StaffGetDTO>().ReverseMap();
            
        }
    }
}
