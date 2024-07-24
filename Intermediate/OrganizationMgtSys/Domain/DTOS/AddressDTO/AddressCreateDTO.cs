namespace OrganizationMgtSys.Domain.DTOS.AddressDTO
{
    public class AddressCreateDTO
    {
        public string StreetName { get; set; } = "street";
        public string State { get; set; } = "State";
        // [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } = "Postal code";
        public string Country { get; set; } = "Country";
    }
}
