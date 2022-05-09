using BankManagementMicroservice.DTOs;
using BankMangementMicroservice.Helpers.JWTWebAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BankMangementMicroservice.Service.Service;
using System.Collections.Generic;
using System;
using BankManagementMicroservice.Service.Model;
using System.Threading.Tasks;

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

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(CustomerDetail usersdata)
        {
            var user = await _customerService.GetCustomer(usersdata);
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
                var result = await _customerService.CreateCustomer(customer);
                return Ok("Successfully Created !!!");
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

        [HttpPost]
        [Route("update-customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDetail customer)
        {
            try
            {
                var result = await _customerService.UpdateCustomer(customer);
                return Ok("Customer account updated Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
       
       
     

       