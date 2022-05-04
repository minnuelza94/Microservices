using BankManagementMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMicroservice.Repository
{
    public interface ICompanyRepositories
    {
        List<CustomerDto> GetAll();

        List<StockExchangeDto> GetAllStock();

        CustomerDto GetCompanyDetailsByCode(string code);

        CustomerDto CreateCompany(CustomerDto companyDetails);

        CustomerDto UpdateCompany(CustomerDto companyDetails);

        bool DeleteCompany(string code);
    }
}
