using Customer_RegistrationWCF.BL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_RegistrationWCF.BL.Repositories
{
    public class CustomerRepository
    {
        private readonly MyDatabaseEntities _myDatabaseEntities;

        public CustomerRepository(MyDatabaseEntities myDatabaseEntities)
        {
            _myDatabaseEntities = myDatabaseEntities;
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _myDatabaseEntities.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            return customer ?? null;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _myDatabaseEntities.Customers.AsNoTracking().ToListAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            _myDatabaseEntities.Customers.Add(customer);
            await _myDatabaseEntities.SaveChangesAsync();
        }

        // I used this approach to avoid having to update the props manually
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _myDatabaseEntities.Customers.Attach(customer);
            _myDatabaseEntities.Entry(customer).State = EntityState.Modified;

            try
            {
                await _myDatabaseEntities.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _myDatabaseEntities.Customers.Where(c => c.Id == customerId).FirstOrDefaultAsync();

            if (customer == null)
            {
                return false;
            }

            _myDatabaseEntities.Customers.Remove(customer);
            await _myDatabaseEntities.SaveChangesAsync();
            return true;
        }
    }
}
