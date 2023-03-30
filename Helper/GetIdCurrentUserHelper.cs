using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Web_Api_Computer_Shop.Helper
{
    public class GetIdCurrentUserHelper : ControllerBase
    {
        public string GetIdCurrentUser(string authHeader) {
            var handler = new JwtSecurityTokenHandler();
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            return tokenS.Claims.First(claim => claim.Type == "id").Value;
        }
    }
}
