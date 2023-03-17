using Customer_RegistrationWCF.BL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_RegistrationWCF.BL.Repositories
{
    public class AddressRepository
    {
        private readonly MyDatabaseEntities _myDatabaseEntities;

        public AddressRepository(MyDatabaseEntities myDatabaseEntities)
        {
            _myDatabaseEntities = myDatabaseEntities;
        }

        public async Task<Address> GetAddressAsync(int addressId)
        {
            var address = await _myDatabaseEntities.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == addressId);
            return address ?? null;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            var addresses = await _myDatabaseEntities.Addresses.AsNoTracking().ToListAsync();
            return addresses;
        }

        public async Task AddAddressAsync(Address address)
        {
            _myDatabaseEntities.Addresses.Add(address);
            await _myDatabaseEntities.SaveChangesAsync();
        }

        public async Task<bool> UpdateCustomerAsync(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _myDatabaseEntities.Addresses.Attach(address);
            _myDatabaseEntities.Entry(address).State = EntityState.Modified;

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

        public async Task<bool> DeleteCustomerAsync(int addressId)
        {
            var address = await _myDatabaseEntities.Addresses.Where(a => a.Id == addressId).FirstOrDefaultAsync();

            if (address == null)
            {
                return false;
            }

            _myDatabaseEntities.Addresses.Remove(address);
            await _myDatabaseEntities.SaveChangesAsync();
            return true;
        }
    }
}
