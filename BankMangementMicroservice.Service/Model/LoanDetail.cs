using System;
using System.ComponentModel.DataAnnotations;

namespace BankManagementMicroservice.Service.Model
{
    public partial class LoanDetail
    {
        public int LoanId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "LoanType cannot exceed 20 characters.")]
        public int LoanType { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal RateofInterest { get; set; }

        [Required]
        public int DurationofLoan { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual CustomerDetail CustomerDetail { get; set; }

        [Required]
        public DateTime CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
    }
}
