using BankManagementMicroservice.Service.Model;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Service.Service
{
    public interface ICustomerService
    {
        Task<CustomerDetail> GetUser(CustomerDetail user);
    }
}
