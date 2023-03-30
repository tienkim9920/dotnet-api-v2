using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Computer_Shop.Model
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "The field with Name of category {0} is required")]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Thumbnail { get; set; }
    }
}
