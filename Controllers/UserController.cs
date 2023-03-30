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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReponsitory userRepository;

        public UserController(IUserReponsitory userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("list")]  // api/users/list
        public ActionResult<List<User>> Get()
        {
            return userRepository.GetAllUsers();
        }

        [Authorize]
        [HttpGet("currentUser", Name = "getCurentUsers")]  // api/users/currentUser
        public ActionResult<User> GetCurrentUser()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "id").Value;
            return userRepository.GetUsersByID(Guid.Parse(id));
        }

        [HttpGet("{Id:Guid}", Name = "getUsers")]  //api/users/{id}
        public ActionResult<User> Get(Guid Id)
        {
            
            return userRepository.GetUsersByID(Id);
        }

        private ActionResult<User> badRequest(object modelstate)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            userRepository.AddUser(user);
            return new CreatedAtRouteResult("getUsers", new { Id = user.ID }, user);
        }

        [HttpPut("{Id:int}", Name = "editUser")]
        public ActionResult Put(string Id, [FromBody] User user)
        {
            if (userRepository.checkExistUser(Id))
            {
                userRepository.EditUser(Id, user);
                return new CreatedAtRouteResult("getUsers", new { Id, user.Name });
            }
            else
            {
                return StatusCode(500, "Id is not exist");
            }
        }

        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            if(userRepository.checkExistUser(Id))
            {
                userRepository.DeleteUser(Id);
                return StatusCode(200);
            } else
            {
                return StatusCode(500, "Id is not exist");
            }
        }
    }
}
