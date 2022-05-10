using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using BankMangementMicroservice.Service.Service;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;
using loanEntity = BankMangementMicroservice.Data.Entity.LoanDetail;

namespace BankMangement.Test
{
    public class CustomerServiceTest
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<ILoanRepository> _loanRepository;
        private Mock<IMapper> _mapper;
        private Mock<ILogger> _logger;
        public customerEntity _customer;
        public customerEntity _customer1;
        public loanEntity _loan;
        public RegisterModel _registerModel;
        public CustomerDetail _customerModel;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _loanRepository = new Mock<ILoanRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger>();
            _loanRepository = new Mock<ILoanRepository>();
            _customer = new customerEntity() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };
            _customer1 = new customerEntity() { CustomerId = 1,Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };
            _loan = new loanEntity() { CustomerId = 1, LoanType = "Personal", LoanAmount = 200000, Date = DateTime.UtcNow, DurationofLoan = 24, RateofInterest = 7 };
            _registerModel = new RegisterModel() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };
            _customerModel = new CustomerDetail() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };

        }



        [Test]
        public void AddCustomer_OkResult()
        {

            // Arrange
            _customerRepository.Setup(x => x.CreateCustomer(_customer));

            var service = new CustomerService(_customerRepository.Object, _mapper.Object, _logger.Object);

            // Act
            var actionResult = service.CreateCustomer(_registerModel);

            // Assert
            Assert.IsNotNull(actionResult);
        }

       
        [Test]
        public void UpdateCustomer_OkResult()
        {
            // Arrange
            _customerRepository.Setup(x => x.GetCustomerById(1)).ReturnsAsync(_customer1);
            _customerRepository.Setup(x => x.UpdateCustomer(_customer1));
            

            var service = new  CustomerService(_customerRepository.Object, _mapper.Object, _logger.Object);

            // Act
            _customerModel.CustomerId = 1;
            var actionResult = service.UpdateCustomer(_customerModel);

            // Assert           
            Assert.IsNotNull(actionResult);
        }
    }
}