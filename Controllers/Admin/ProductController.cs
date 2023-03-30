using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Controllers.Admin
{
    [Route("api/admin/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("{Id:Guid}", Name = "getProductById")]  // api/
        public ActionResult<PagedResponse<Product>> GetAll()
        {
            try
            {
                return Ok(productRepository.GetAllProduct());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]  // api/
        public ActionResult<PagedResponse<Product>> GetById(Guid Id)
        {
            try
            {
                return Ok(productRepository.GetProductByID(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("paging")]  // api/paging
        public ActionResult<PagedResponse<Product>> GetAllPaging([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                return Ok(productRepository.GetAllProductPaging(paginationQuery));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("multi")]  // api/multi
        public ActionResult<PagedResponse<Product>> AddMultiProduct(List<Product> products)
        {
            try
            {
                return Ok(productRepository.AddMultiProduct(products));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]  // api/multi
        public ActionResult<PagedResponse<Product>> Delete(Guid Id)
        {
            try
            {
                productRepository.DeleteProduct(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("multi")]  // api/multi
        public ActionResult<PagedResponse<Product>> Delete(List<Guid> Ids)
        {
            try
            {
                productRepository.DeleteMultiProduct(Ids);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Id:int}", Name = "editProduct")]
        public ActionResult Put(Guid Id, [FromBody] Product product)
        {
            try
            {
                productRepository.EditProduct(Id, product);
                return new CreatedAtRouteResult("getUsers", new { Id, product });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult ImportCsv(IFormFile file)
        {
            try
            {
                productRepository.ImportCsv(file);
                //return new CreatedAtRouteResult("getUsers", new { Id, product });
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
