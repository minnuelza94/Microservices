using BankManagementMicroservice.DTOs;
using BankManagementMicroservice.Service.Model;

namespace BankMangementMicroservice.Helpers.JWTWebAuthentication
{
    public interface IJWTManager
    {
        Tokens Authenticate(CustomerDetail users);
    }
}
