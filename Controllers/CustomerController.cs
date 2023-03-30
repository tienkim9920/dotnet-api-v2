using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [Authorize]
        [HttpGet("list")]  // api/customers/list
        public ActionResult<List<Customer>> Get()
        {
            return customerRepository.GetAllCustomer();
        }

        [Authorize]
        [HttpGet("currentCustomer", Name = "getCurrentCustomer")]  // api/customers/currentUser
        public ActionResult<Customer> GetCurrentUser()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "id").Value;
            return customerRepository.GetCustomerByID(Guid.Parse(id));
        }

        [HttpGet("{Id:Guid}", Name = "getCustomer")]  //api/customers/{id}
        public ActionResult<Customer> Get(Guid Id)
        {

            return customerRepository.GetCustomerByID(Id);
        }

        private ActionResult<Customer> badRequest(object modelstate)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            customerRepository.AddCustomer(customer);
            return new CreatedAtRouteResult("getUsers", new { Id = customer.Id }, customer);
        }

        [HttpPut("{Id:int}", Name = "editCustomer")]
        public ActionResult Put(string Id, [FromBody] Customer customer)
        {
            try
            {
                if (customerRepository.CheckExistCustomer(Id))
                {
                    customerRepository.EditCustomer(Id, customer);
                    return new CreatedAtRouteResult("getUsers", new { Id, customer });
                }
                else
                {
                    return StatusCode(500, "Id is not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            if (customerRepository.CheckExistCustomer(Id))
            {
                customerRepository.DeleteCustomer(Id);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(500, "Id is not exist");
            }
        }
    }
}
