namespace BankManagementMicroservice.Model
{
    public partial class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string PAN { get; set; }
        public string DOB { get; set; }
        public long ContactNo { get; set; }
        public string AccountType { get; set; }

    }
}
