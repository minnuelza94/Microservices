using BankManagementMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMicroservice.Repository.JWTWebAuthentication
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(CustomerDto users);
    }
}
