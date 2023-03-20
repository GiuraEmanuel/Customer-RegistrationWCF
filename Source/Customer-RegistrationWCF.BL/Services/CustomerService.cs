using Customer_RegistrationWCF.BL.Data;
using Customer_RegistrationWCF.BL.Interfaces;
using Customer_RegistrationWCF.BL.Mappers;
using Customer_RegistrationWCF.Common.Dtos.Address;
using Customer_RegistrationWCF.Common.Dtos.Customer;
using Customer_RegistrationWCF.Common.Dtos.Customers;
using Customer_RegistrationWCF.Common.Validators;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_RegistrationWCF.BL.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly MyDatabaseEntities _dbEntities;

        public CustomerService(MyDatabaseEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public async Task<List<GetAllCustomersDto>> GetAllCustomers()
        {
            var customers = await _dbEntities.Customers.ToListAsync();
            var customersDto = CustomerMapper.MapToListOfCustomerDto(customers);

            return customersDto;
        }

        public async Task CustomerDetails(int customerId)
        {
            var customerInfo = await _dbEntities.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new CustomerDetailsDto(
                    c.Id,
                    c.Name,
                    c.Website,
                    c.Email,
                    c.PhoneNumber,
                    new AddressDto(
                        c.PostalAddress.Street,
                        c.PostalAddress.Number,
                        c.PostalAddress.PostCode,
                        c.PostalAddress.City,
                        c.PostalAddress.Country
                    ),
                    new AddressDto(
                        c.InvoiceAddress.Street,
                        c.InvoiceAddress.Number,
                        c.InvoiceAddress.PostCode,
                        c.InvoiceAddress.City,
                        c.InvoiceAddress.Country
                    )
                ))
                .SingleOrDefaultAsync();
        }

        public void AddCustomer(AddCustomerDto addCustomerDto)
        {
            var validator = new AddCustomerDtoValidator();
            var result = validator.Validate(addCustomerDto);

            if (result.IsValid)
            {
                var customer = new Customer
                {
                    Name = addCustomerDto.Name,
                    Website = addCustomerDto.Website,
                    Email = addCustomerDto.Email,
                    PhoneNumber = addCustomerDto.PhoneNumber,
                    PostalAddress = new Address
                    {
                        Street = addCustomerDto.PostalAddressStreet,
                        Number = addCustomerDto.PostalAddressStreetNumber,
                        PostCode = addCustomerDto.PostalAddressPostCode,
                        City = addCustomerDto.PostalAddressCity,
                        Country = addCustomerDto.PostalAddressCountry
                    }
                };

                if (!addCustomerDto.IsInvoiceAddressDifferent)
                    customer.InvoiceAddress = customer.PostalAddress;
                else
                    customer.InvoiceAddress = new Address
                    {
                        Number = addCustomerDto.InvoiceAddressStreetNumber,
                        PostCode = addCustomerDto.InvoiceAddressPostCode,
                        City = addCustomerDto.InvoiceAddressCity,
                        Country = addCustomerDto.InvoiceAddressCountry
                    };

                _dbEntities.Customers.Add(customer);
                _dbEntities.SaveChanges();
            }
        }
    }
}
