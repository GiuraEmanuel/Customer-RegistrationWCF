namespace Customer_RegistrationWCF.Common.Dtos.Customer
{
    public class AddCustomerDto
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PostalAddressStreet { get; set; }

        public string PostalAddressStreetNumber { get; set; }

        public string PostalAddressPostCode { get; set; }

        public string PostalAddressCity { get; set; }

        public string PostalAddressCountry { get; set; }

        public string InvoiceAddressStreet { get; set; }

        public string InvoiceAddressStreetNumber { get; set; }

        public string InvoiceAddressPostCode { get; set; }

        public string InvoiceAddressCity { get; set; }

        public string InvoiceAddressCountry { get; set; }

        public bool IsInvoiceAddressDifferent { get; set; }
    }
}
