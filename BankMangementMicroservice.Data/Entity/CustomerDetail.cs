using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankMangementMicroservice.Data.Entity
{
    public partial class CustomerDetail
    {

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }


        [Required]
        public string Password { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PAN { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public long ContactNo { get; set; }

        [Required]
        public string AccountType { get; set; }
        [Required]

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
        public virtual List<LoanDetail> LoanDeatils { get; set; }


    }
}
