using BankMangementMicroservice.Data.DBContexts;
using BankMangementMicroservice.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Data.Repository
{
    public class CustomerRepostory : ICustomerRepository
    {
        private CustomerDbContext _customerDbContext;

        public CustomerRepostory(CustomerDbContext customerDbContext)
        {
            this._customerDbContext = customerDbContext;
        }

        public async Task<CustomerDetail> GetUser(CustomerDetail customer)
        {
            var user = await _customerDbContext.CustomerDetail.FirstOrDefaultAsync(x => x.Username == customer.Username && x.Password == customer.Password);
            return user;
        }

        public async Task<bool> IsCustomerIdExists(int id)
        {
            bool isExist = await _customerDbContext.CustomerDetail.Where(x => x.CustomerId == id).AnyAsync();
            return isExist;

        }

        public async Task<CustomerDetail> GetCustomerById(int id)
        {
            var data = await _customerDbContext.CustomerDetail.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<CustomerDetail> CreateCustomer(CustomerDetail customer)
        {
            await _customerDbContext.CustomerDetail.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
            return customer;

        }

        public async Task<CustomerDetail> UpdateCustomer(CustomerDetail customer)
        {
             _customerDbContext.CustomerDetail.Update(customer);
            await _customerDbContext.SaveChangesAsync();
            return customer;

        }

        public async Task<List<CustomerDetail>> GetAllCustomerDetails()
        {
            var data = await _customerDbContext.CustomerDetail.ToListAsync();
            return data;
        }
    }
}
