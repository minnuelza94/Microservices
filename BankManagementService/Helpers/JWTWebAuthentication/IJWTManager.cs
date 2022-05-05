using BankManagementMicroservice.DTOs;

namespace BankMangementMicroservice.Helpers.JWTWebAuthentication
{
    public interface IJWTManager
    {
        Tokens Authenticate(CustomerDto users);
    }
}
