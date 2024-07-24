namespace OrganizationMgtSys.Domain.DTOS.AddressDTO
{
    public class AddressGetDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string State { get; set; }
        // [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } 
        public string Country { get; set; }
    }
}
