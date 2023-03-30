using System;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Model
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Customer user, string token)
        {
            Id = user.Id;
            Name = user.Full_Name;
            IsAdmin = true;
            Token = token;
        }
    }
}
