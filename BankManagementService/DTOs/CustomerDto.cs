using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMicroservice.DTOs
{
    public class CustomerDto
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCeo { get; set; }
        public decimal Turnover { get; set; }
        public string Website { get; set; }
        public string StockExchange { get; set; }
        public int StockExchangeID { get; set; }
    }
}
