using BankMangementMicroservice.Data.Entity;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Data.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> DoesUserExists(CustomerDetail customer);
        //List<Cu>stomerDto> GetAll();

        //List<StockExchangeDto> GetAllStock();

        //CustomerDto GetCompanyDetailsByCode(string code);

        //CustomerDto CreateCompany(CustomerDto companyDetails);

        //CustomerDto UpdateCompany(CustomerDto companyDetails);

        //bool DeleteCompany(string code);
    }
}
