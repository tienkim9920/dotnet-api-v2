using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Controllers.Admin
{
    [Route("api/admin/option")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionRepository optionRepository;
        public OptionController(IOptionRepository optionRepository)
        {
            this.optionRepository = optionRepository;
        }

        [HttpGet]  // api/customers
        public ActionResult<List<Option>> Get()
        {
            try
            {
                return optionRepository.GetAllOption();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{Id:Guid}", Name = "getOptionById")]  //api/customers/{id}
        public ActionResult<Option> Get(Guid Id)
        {
            try
            {
                return optionRepository.GetOptionByID(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Option option)
        {
            try
            {
                optionRepository.AddOption(option);
                return new CreatedAtRouteResult("GetOption", new { Id = option.Id }, option);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id:int}", Name = "editOption")]
        public ActionResult Put(Guid Id, [FromBody] Option option)
        {
            try
            {
                optionRepository.EditOption(Id, option);
                return new CreatedAtRouteResult("getOption", new { Id, option });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(Guid Id)
        {
            try
            {
                optionRepository.DeleteOption(Id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
