using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Computer_Shop.Entities
{
    public class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        [FirstLetterUppercase]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created_Date { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Modified_Date { get; set; }
    }
}

