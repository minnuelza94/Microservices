using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using BankMangementMicroservice.Service.Service;
using Microsoft.AspNetCore.Mvc;
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
        public loanEntity _loan;
        public RegisterModel _registerModel;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _loanRepository = new Mock<ILoanRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger>();
            _loanRepository = new Mock<ILoanRepository>();
            _customer = new customerEntity() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };
            _loan = new loanEntity() { CustomerId = 1, LoanType = "Personal", LoanAmount = 200000, Date = DateTime.UtcNow, DurationofLoan = 24, RateofInterest = 7 };
            _registerModel = new RegisterModel() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailAddress = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedOnUtc = DateTime.UtcNow, PAN = "BPFPN9256N" };

        }
        #region Validations


        [Test]
        public void AddCustomer_OkResult()
        {

            // Arrange
            _customerRepository.Setup(x => x.CreateCustomer(_customer));

            var service = new CustomerService(_customerRepository.Object, _mapper.Object, _logger.Object);

            // Act
            var actionResult = service.CreateCustomer(_registerModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void AddCustomer_ThrowsException()
        {
            // Arrange
            _customerService.Setup(x => x.CreateNewCustomer(_customer)).Throws(new Exception());
            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.AddCustomer(_customer));
        }

        [Test]
        public void UpdateCustomer_OkResult()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomerInfo(_customer));

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Act
            var actionResult = controller.UpdateCustomer(_customer);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void Updatecustomer_ThorowsException()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomerInfo(_customer)).Throws(new Exception());

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.UpdateCustomer(_customer));
        }

        [Test]
        public void ApplyLoan_OkResult()
        {
            // Arrange
            _loanService.Setup(x => x.ApplyLoan(_loan));

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Act
            var actionResult = controller.ApplyLoan(_loan);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void Updatecustomer_ThrowsException()
        {
            // Arrange
            _loanService.Setup(x => x.ApplyLoan(_loan)).Throws(new Exception());

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.ApplyLoan(_loan));
        }
        #endregion
    }
}