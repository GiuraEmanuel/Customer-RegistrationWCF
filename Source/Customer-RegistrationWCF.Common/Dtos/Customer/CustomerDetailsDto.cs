using Customer_RegistrationWCF.Common.Dtos.Address;

namespace Customer_RegistrationWCF.Common.Dtos.Customers
{
    public class CustomerDetailsDto
    {
        public CustomerDetailsDto(int id, string name, string website, string email,
            string phoneNumber, AddressDto invoiceAddress, AddressDto postalAddress)
        {
            Id = id;
            Name = name;
            Website = website;
            Email = email;
            PhoneNumber = phoneNumber;
            InvoiceAddress = invoiceAddress;
            PostalAddress = postalAddress;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public AddressDto InvoiceAddress { get; set; }

        public AddressDto PostalAddress { get; set; }
    }
}
