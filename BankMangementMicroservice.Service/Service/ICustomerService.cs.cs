using BankManagementMicroservice.Service.Model;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;
using System.Threading.Tasks;
using System.Collections.Generic;
using BankMangementMicroservice.Service.Model;

namespace BankMangementMicroservice.Service.Service
{
    public interface ICustomerService
    {
        Task<CustomerDetail> GetCustomer(LoginModel user);
        Task<customerEntity> GetCustomerById(int id);
        Task<List<CustomerDetail>> GetAllCustomers();
        Task<CustomerDetail> CreateCustomer(CustomerDetail customer);
        Task<CustomerDetail> UpdateCustomer(CustomerDetail customer);
    }
}
