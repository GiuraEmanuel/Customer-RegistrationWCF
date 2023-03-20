using Customer_RegistrationWCF.Common.Dtos.Customer;
using FluentValidation;
namespace Customer_RegistrationWCF.Common.Validators
{
    public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Website).MaximumLength(100);
            RuleFor(x => x.Email).MaximumLength(100).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(15);
            RuleFor(x => x.PostalAddressStreet).MaximumLength(100);
            RuleFor(x => x.PostalAddressStreetNumber).MaximumLength(100);
            RuleFor(x => x.PostalAddressPostCode).MaximumLength(100);
            RuleFor(x => x.PostalAddressCity).MaximumLength(100);
            RuleFor(x => x.PostalAddressCountry).MaximumLength(100);

            RuleSet("InvoiceAddress", () =>
            {
                RuleFor(x => x.InvoiceAddressStreet).NotEmpty().When(x => x.IsInvoiceAddressDifferent);
                RuleFor(x => x.InvoiceAddressStreetNumber).NotEmpty().When(x => x.IsInvoiceAddressDifferent);
                RuleFor(x => x.InvoiceAddressPostCode).NotEmpty().When(x => x.IsInvoiceAddressDifferent);
                RuleFor(x => x.InvoiceAddressCity).NotEmpty().When(x => x.IsInvoiceAddressDifferent);
                RuleFor(x => x.InvoiceAddressCountry).NotEmpty().When(x => x.IsInvoiceAddressDifferent);
            });
        }
    }
}
