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
    [Route("api/admin/subCategory")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly GetIdCurrentUserHelper getIdCurrentUserHelper = new GetIdCurrentUserHelper();
        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        [HttpGet]  // api/
        public ActionResult<List<SubCategory>> Get()
        {
            try
            {
                return subCategoryRepository.GetAllSubCategory();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paging")]  // api/paging
        public ActionResult<PagedResponse<SubCategory>> GetAllPaging([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                return Ok(subCategoryRepository.GetAllSubCategoryPaging(paginationQuery));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getListNotChild")]
        public ActionResult<List<SubCategory>> GetNotChild()
        {
            try
            {
                return Ok(subCategoryRepository.GetListNotChildSubCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getListChildByParentId/{Id:Guid}", Name = "getListChildByParentId")]
        public ActionResult<List<Product>> GetListChild(Guid Id)
        {
            try
            {
                return Ok(subCategoryRepository.GetListChildSubCategory(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id:Guid}", Name = "getSubCategory")]  //api//{id}
        public ActionResult<SubCategory> Get(Guid Id)
        {
            try
            {
                return subCategoryRepository.GetSubCategoryByID(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private ActionResult<SubCategory> badRequest(object modelstate)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] SubCategoryRequest subCategoryRequest)
        {
            try
            {
                //Add log history before excuted add category
                Guid UserId = Guid.Parse(getIdCurrentUserHelper.GetIdCurrentUser(Request.Headers["Authorization"]));
                var subCategory = new SubCategory();
                subCategory.Name = subCategoryRequest.Name;
                subCategory.Description = subCategoryRequest.Description;
                subCategory.Thumnail = subCategoryRequest.Thumnail;
                //subCategory.CategoryId = subCategoryRequest.CategoryId;
                subCategoryRepository.AddSubCategory(subCategory, UserId);
                return new CreatedAtRouteResult("getUsers", new { Id = subCategory.Id }, subCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id:int}", Name = "editSubCategory")]
        public ActionResult Put(Guid Id, [FromBody] SubCategory subCategory)
        {
            try
            {
                //Add log history before excuted add category
                Guid UserId = Guid.Parse(getIdCurrentUserHelper.GetIdCurrentUser(Request.Headers["Authorization"]));
                subCategoryRepository.EditSubCategory(Id, UserId, subCategory);
                return new CreatedAtRouteResult("getUsers", new { Id, subCategory });
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
                subCategoryRepository.DeleteSubCategory(Id, UserId);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
