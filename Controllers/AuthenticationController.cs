using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Todo_List.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationReponsitory _authenticationRepository;

        public AuthenticationController(IAuthenticationReponsitory authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost("signIn")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _authenticationRepository.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

        [HttpPost("signUp")]
        public IActionResult Authenticate(SignUpRequest model)
        {
            var response = _authenticationRepository.SignUp(model);

            if (response == null)
            {
                return BadRequest(new { message = "Create account failed" });
            }

            return Ok(response);
        }
        [HttpPost("forgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordRequest model)
        {
            try
            {
                var response = _authenticationRepository.ForgotPassword(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("changePassword")]
        public IActionResult ChangePassword(ChangePasswordRequest model)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = Guid.Parse(tokenS.Claims.First(claim => claim.Type == "id").Value);
            try
            {
                var response = _authenticationRepository.ChangePassword(model,id);
                return Ok(response);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
