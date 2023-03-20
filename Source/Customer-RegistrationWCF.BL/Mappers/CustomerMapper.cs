using Customer_RegistrationWCF.BL.Data;
using Customer_RegistrationWCF.Common.Dtos.Customer;
using System.Collections.Generic;

namespace Customer_RegistrationWCF.BL.Mappers
{
    public static class CustomerMapper
    {
        public static List<GetAllCustomersDto> MapToListOfCustomerDto(List<Customer> customers)
        {
            var customerDtos = new List<GetAllCustomersDto>();

            foreach (var customer in customers)
            {
                var customerDto = new GetAllCustomersDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Website = customer.Website,
                    PhoneNumber = customer.PhoneNumber
                };

                customerDtos.Add(customerDto);
            }

            return customerDtos;
        }
    }
}
