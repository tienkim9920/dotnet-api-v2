using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;
namespace Web_Api_Computer_Shop.Controllers.Admin
{
    [Authorize]
    [Route("api/admin/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly GetIdCurrentUserHelper getIdCurrentUserHelper = new GetIdCurrentUserHelper();
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
       
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            try
            {
                return categoryRepository.GetAllCategory();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paging")]  // api/customers
        public ActionResult<PagedResponse<Category>> GetAllPaging([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                return Ok(categoryRepository.GetAllCategoryPaging(paginationQuery));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id:Guid}", Name = "getCategoryById")]  //api/customers/{id}
        public ActionResult<Category> Get(Guid Id)
        {
            try
            {
                return categoryRepository.GetCategoryByID(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] CategoryRequest categoryRequest)
        {
            try
            {
                //Add log history before excuted add category
                Guid UserId = Guid.Parse(getIdCurrentUserHelper.GetIdCurrentUser(Request.Headers["Authorization"]));
                var category = new Category();
                category.Name = categoryRequest.Name;
                category.Description = categoryRequest.Description;
                category.Thumbnail = categoryRequest.Thumbnail;
                //Excuted add category
                categoryRepository.AddCategory(category, UserId);
                return new CreatedAtRouteResult("getUsers", new { Id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id:int}", Name = "editCategory")]
        public ActionResult Put(Guid Id, [FromBody] Category category)
        {
            try
            {
                //Add log history before excuted add category
                Guid UserId = Guid.Parse(getIdCurrentUserHelper.GetIdCurrentUser(Request.Headers["Authorization"]));
                categoryRepository.EditCategory(Id,UserId, category);
                return new CreatedAtRouteResult("getUsers", new { Id, category });
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
                //Add log history before excuted add category
                Guid UserId = Guid.Parse(getIdCurrentUserHelper.GetIdCurrentUser(Request.Headers["Authorization"]));
                categoryRepository.DeleteCategory(Id, UserId);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
