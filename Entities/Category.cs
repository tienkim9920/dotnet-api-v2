using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field with Name of category {0} is required")]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Thumbnail { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
