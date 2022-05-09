using BankManagementMicroservice.Service.Model;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Service.Service
{
    public interface ICustomerService
    {
        Task<CustomerDetail> GetCustomer(CustomerDetail user);
        Task<customerEntity> GetCustomerById(int id);
        Task<CustomerDetail> CreateCustomer(CustomerDetail customer);
        Task<CustomerDetail> UpdateCustomer(CustomerDetail customer);
    }
}
