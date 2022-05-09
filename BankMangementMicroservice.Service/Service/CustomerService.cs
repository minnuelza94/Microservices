using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task<CustomerDetail> GetCustomer(CustomerDetail user)
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


        public async Task<CustomerDetail> CreateCustomer(CustomerDetail customer)
        {

            customer.CreatedOnUtc = DateTime.UtcNow;
            var data = _mapper.Map<customerEntity>(customer);
            _logger.LogInformation("Registering new customer in the DB");
            await _customerRepository.CreateCustomer(data);
            _logger.LogInformation("Data saved in the DB");
            return customer;

        }

        public async Task<CustomerDetail> UpdateCustomer(CustomerDetail customer)
        {
            var customerData = await _customerRepository.GetCustomerById(customer.CustomerId);
            if (customerData == null)
            {
                throw new Exception("Customer Not Found");
            }
            customerData.UpdatedOnUtc = DateTime.UtcNow;
            _logger.LogInformation("Registering new customer in the DB");
            await _customerRepository.UpdateCustomer(customerData);
            _logger.LogInformation("Data saved in the DB");
            return customer;

        }

    }
}
