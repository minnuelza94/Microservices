using BankMangementMicroservice.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Data.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDetail> GetUser(CustomerDetail customer);
        Task<bool> IsCustomerIdExists(int id);
        Task<CustomerDetail> GetCustomerById(int id);
        Task<CustomerDetail> CreateCustomer(CustomerDetail customer);
        Task<CustomerDetail> UpdateCustomer(CustomerDetail customer);
        Task<List<CustomerDetail>> GetAllCustomerDetails();
    }
}
