using BankMangementMicroservice.Data.DBContexts;
using BankMangementMicroservice.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankMangementMicroservice.Data.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private CustomerDbContext _customerDbContext;

        public LoanRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<LoanDetail> ApplyLoan(LoanDetail loan)
        {
            await _customerDbContext.LoanDetail.AddAsync(loan);
            await _customerDbContext.SaveChangesAsync();
            return loan;

        }
        public async Task<List<LoanDetail>> GetAllLoan()
        {
            var Loans = await _customerDbContext.LoanDetail.ToListAsync();
            return Loans;

        }
    }
}

