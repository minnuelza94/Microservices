using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using loanDetail = BankMangementMicroservice.Data.Entity.LoanDetail;

namespace BankMangementMicroservice.Service.Service
{
    public class LoanService : ILoanService
    {

        private readonly ILoanRepository _loanRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public LoanService(ILoanRepository loanRepository, ICustomerRepository customerRepository, IMapper mapper, ILogger<LoanService> logger)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<LoanDetail> ApplyLoan(LoanDetail loan)
        {

            if (!await _customerRepository.IsCustomerIdExists(loan.CustomerId))
            {
                throw new Exception("Customer Id doesn't exists");
            }
            var data = _mapper.Map<loanDetail>(loan);
            await _loanRepository.ApplyLoan(data);
            return loan;
        }
        public async Task<List<LoanDetail>> GetAllLoan()
        {
            var loans = await _loanRepository.GetAllLoan();
            return _mapper.Map<List<LoanDetail>>(loans);
        }
    }
}
