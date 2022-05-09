using BankMangementMicroservice.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Data.Repository
{
    public interface ILoanRepository
    {
        Task<LoanDetail> ApplyLoan(LoanDetail loan);
        Task<List<LoanDetail>> GetAllLoan();
    }
}
