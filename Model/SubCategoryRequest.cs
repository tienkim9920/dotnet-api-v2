using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Computer_Shop.Model
{
    public class SubCategoryRequest
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field Name Subcategory {0} is required")]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Thumnail { get; set; }
    }
}
