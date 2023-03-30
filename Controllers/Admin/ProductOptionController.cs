using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Controllers.Admin
{
    [Route("api/admin/productOption")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly IOptionProductRepository optionProductRepository;
        public ProductOptionController(IOptionProductRepository optionProductRepository)
        {
            this.optionProductRepository = optionProductRepository;
        }

        [HttpGet]  // api/productOption
        public ActionResult<List<ProductOption>> Get()
        {
            try
            {
                return optionProductRepository.GetAllProductOption();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{Id:Guid}", Name = "getProductOptionById")]  //api/customers/{id}
        public ActionResult<ProductOption> Get(Guid Id)
        {
            try
            {
                return optionProductRepository.GetProductOptionByID(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] ProductOption productOption)
        {
            try
            {
                optionProductRepository.AddProductOption(productOption);
                return new CreatedAtRouteResult("GetProductOption", new { Id = productOption.Id }, productOption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id:int}", Name = "editProductOption")]
        public ActionResult Put(Guid Id, [FromBody] ProductOption productOption)
        {
            try
            {
                optionProductRepository.EditProductOption(Id, productOption);
                return new CreatedAtRouteResult("getProductOption", new { Id, productOption });
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
                optionProductRepository.DeleteProductOption(Id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
