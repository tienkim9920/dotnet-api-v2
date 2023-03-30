using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Api_Computer_Shop.Enum;

namespace Web_Api_Computer_Shop.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field CategoryId {0} is required")]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Thumnail { get; set; }
        public ELevel level { get; set; }
        public bool IsPublish { get; set; }
        public Nullable<Guid> CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Nullable<Guid> SubCategoryParrentId { get; set; }
        public virtual SubCategory SubCategoryParrent { get; set; }
        public virtual ICollection<SubCategoryDetail> SubCategoryDetails { get; set; }
        //public virtual ICollection<Option> Options { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
