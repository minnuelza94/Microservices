using BankManagementMicroservice.Service.Model;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BankMangementMicroservice.Service.Service
{
    public interface ICustomerService
    {
        Task<CustomerDetail> GetCustomer(CustomerDetail user);
        Task<customerEntity> GetCustomerById(int id);
        Task<List<customerEntity>> GetAllCustomers();
        Task<CustomerDetail> CreateCustomer(CustomerDetail customer);
        Task<CustomerDetail> UpdateCustomer(CustomerDetail customer);
    }
}
