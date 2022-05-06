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
        private ICustomerService _customerService;
        private readonly IJWTManager _jWTManager;

        public CustomerController(ICustomerService customerService,
                                  IJWTManager jWTManager)
        {

            this._customerService = customerService;
            this._jWTManager = jWTManager;
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
            var user = await _customerService.GetUser(usersdata);
            if (user != null)
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

        //[HttpGet]
        //[Route("getcustomer/{id}")]
        //public IActionResult GetCustomerById(string customerId)
        //{
        //    try
        //    {
        //        var customer = _customerService.GetCustomerById();
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(customer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        //[HttpGet]
        //[Route("getallStock")]
        //public IActionResult GetAllStock()
        //{
        //    try
        //    {
        //        var stock = companyRepositories.GetAllStock();
        //        if (stock == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(stock);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        //[Route("info/{code}")]
        //[HttpGet]
        //public IActionResult GetCompanyById(string code)
        //{
        //    try
        //    {
        //        var company = companyRepositories.GetCompanyDetailsByCode(code);
        //        if (company == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(company);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[Route("delete/{code}")]
        //[HttpDelete]
        //public IActionResult DeleteCompanyByCode(string code)
        //{
        //    try
        //    {
        //        var company = companyRepositories.DeleteCompany(code);
        //        if (!company)
        //        {
        //            return NotFound();
        //        }

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[Route("register")]
        //[HttpPost]
        //public IActionResult CreateRegister([FromBody] CustomerDto companyDetail)
        //{
        //    try
        //    {
        //        var company = companyRepositories.CreateCompany(companyDetail);
        //        if (company == null)
        //        {
        //            return BadRequest();
        //        }

        //        return Created("Success", company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequest(ex.Message.ToString());
        //    }
        //}


        //[Route("UpdateCompany/{code}")]
        //[HttpPut]
        //public IActionResult UpdateRegister([FromBody] CustomerDto companyDetail)
        //{
        //    try
        //    {
        //        var company = companyRepositories.UpdateCompany(companyDetail);
        //        if (company == null)
        //        {
        //            return BadRequest();
        //        }

        //        return Ok(company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequest(ex.Message.ToString());
        //    }
        //}
    }
}
