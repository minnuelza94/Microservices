using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using BankMangementMicroservice.Service.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;

namespace BankMangementMicroservice.Service.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CustomerService(ICustomerRepository customerRepository,
            IMapper mapper,
            ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDetail> GetCustomer(LoginModel user)
        {
            var userData = _mapper.Map<customerEntity>(user);
            var data = await _customerRepository.GetUser(userData);
            return _mapper.Map<CustomerDetail>(data);
        }

        public async Task<customerEntity> GetCustomerById(int id)
        {
            var data = await _customerRepository.GetCustomerById(id);
            return data;
        }

        public async Task<List<CustomerDetail>> GetAllCustomers()
        {
            var data = await _customerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerDetail>>(data);
        }



        public async Task<CustomerDetail> CreateCustomer(RegisterModel customer)
        {

            customer.CreatedOnUtc = DateTime.UtcNow;
            var data = _mapper.Map<customerEntity>(customer);
            _logger.LogInformation("Registering new customer in the DB");
            await _customerRepository.CreateCustomer(data);
            _logger.LogInformation("Data saved in the DB");
            return _mapper.Map<CustomerDetail>(data);

        }

        public async Task<CustomerDetail> UpdateCustomer(CustomerDetail customer)
        {
            var customerData = await _customerRepository.GetCustomerById(customer.CustomerId);
            if (customerData == null)
            {
                throw new Exception("Customer Not Found"); 
            }

            var data = _mapper.Map<CustomerDetail, customerEntity>(customer);
            data.UpdatedOnUtc = DateTime.UtcNow;
            data.Password = customerData.Password;
            _logger.LogInformation("Registering new customer in the DB");
            await _customerRepository.UpdateCustomer(data);
            _logger.LogInformation("Data saved in the DB");
            return _mapper.Map<CustomerDetail>(data);

        }

    }
}
