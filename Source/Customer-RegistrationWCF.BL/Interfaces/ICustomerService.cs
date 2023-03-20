using Customer_RegistrationWCF.Common.Dtos.Customer;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Customer_RegistrationWCF.BL.Interfaces
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Task<List<GetAllCustomersDto>> GetAllCustomers();

        [OperationContract]
        Task CustomerDetails(int customerId);

        [OperationContract]
        void AddCustomer(AddCustomerDto  addCustomerDto);
    }
}
