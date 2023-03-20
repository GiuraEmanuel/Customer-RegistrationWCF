namespace Customer_RegistrationWCF.Common.Dtos.Address
{
    public class AddressDto
    {
        public AddressDto(string street, string number, string postCode,
            string city, string country)
        {
            Street = street;
            Number = number;
            PostCode = postCode;
            City = city;
            Country = country;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
