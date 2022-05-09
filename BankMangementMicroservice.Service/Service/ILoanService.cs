using BankManagementMicroservice.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Service.Service
{
    public interface ILoanService
    {
        Task<LoanDetail> ApplyLoan(LoanDetail loan);

        Task<List<LoanDetail>> GetAllLoan();
    }
}
