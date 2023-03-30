using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Computer_Shop.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class ForgotPasswordRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string New_Password { get; set; }
    }

    public class ChangePasswordRequest
    {
        [Required]
        public string Old_Password { get; set; }
        [Required]
        public string New_Password { get; set; }
    }
}
