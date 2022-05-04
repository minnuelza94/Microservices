using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMicroservice.Model
{
    public partial class LoanDetail
    {
    
        public int LoanType { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime Date { get; set; }
        public decimal RateofInterest { get; set; }
        public int DurationofLoan { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDetail CustomerDetail { get; set; }
    }
}
