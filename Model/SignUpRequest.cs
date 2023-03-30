using System.ComponentModel.DataAnnotations;

namespace Web_Api_Computer_Shop.Model
{
    public class SignUpRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
