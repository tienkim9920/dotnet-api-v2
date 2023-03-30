using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Option
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field with OptionName {0} is required")]
        public String OptionName { get; set; }
        public String Type { get; set; }

        //Many relationship
        //public Nullable<Guid> SubCategoryId { get; set; }
        //public virtual SubCategory SubCategory { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
