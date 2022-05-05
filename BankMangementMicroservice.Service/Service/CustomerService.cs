using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Data.Repository;
using System.Threading.Tasks;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;

namespace BankMangementMicroservice.Service.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<bool> DoesUserExists(CustomerDetail user)
        {
            var userData = _mapper.Map<customerEntity>(user);
            return await _customerRepository.DoesUserExists(userData);
        }
    }
}
