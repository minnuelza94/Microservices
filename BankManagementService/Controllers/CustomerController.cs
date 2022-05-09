using BankMangementMicroservice.Helpers.JWTWebAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BankMangementMicroservice.Service.Service;
using System;
using BankManagementMicroservice.Service.Model;
using System.Threading.Tasks;
using BankManagementMicroservice.Helpers;
using BankMangementMicroservice.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankManagementMicroservice.Controllers
{
    [Authorize]
    [Route("api/v1.0/customer/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IJWTManager _jWTManager;
        private readonly ILoanService _loanService;

        public CustomerController(ICustomerService customerService, 
                                  IJWTManager jWTManager,
                                  ILoanService loanService)
        {

            this._customerService = customerService;
            this._jWTManager = jWTManager;
            this._loanService = loanService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel login)
        {
            var user = await _customerService.GetCustomer(login);
            if (user == null)
            {
                return NotFound();
            }
            var token = _jWTManager.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CustomerDetail customer)
        {
            try
            {
                isValid(customer);
                var result = await _customerService.CreateCustomer(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("applyloan")]
        public async Task<IActionResult> ApplyLoan([FromBody] LoanDetail loan)
        {
            try
            {
                var result = await _loanService.ApplyLoan(loan);
                return Ok("Loan Applied Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update-customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDetail customer)
        {
            try
            {
                var result = await _customerService.UpdateCustomer(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getcustomer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getallcustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var result = await _customerService.GetAllCustomers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getalloan")]
        public async Task<IActionResult> GetAllLoan()
        {
            try
            {
                var result = await _loanService.GetAllLoan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void isValid(CustomerDetail customer)
        {
           
            if (!ValidCheck.IsValidEmail(customer.EmailAddress))
                throw new Exception("Email Address is not valid.");
            if (!ValidCheck.IsValidMobileNumber(customer.ContactNo))
                throw new Exception("Phone Number is not valid.");
        }
        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //[Route("get-loan-details")]
        //public IActionResult GetAllLoanDetails()
        //{
        //    return Ok(_loanService.GetAllLoanDetails());
        //}

        //[HttpGet, Authorize(Roles = "admin"), Route("get-customer-details")]
        //public IActionResult GetAccountDetails()
        //{
        //    return Ok(_registerService.GetAccountDetails());
        //}
    }
}
       
       
     

       