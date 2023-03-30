using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; }
        [Required(ErrorMessage = "The field with sku {0} is required")]
        public string Sku { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field with price {0} is required")]
        public string Price { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public bool Stock { get; set; } = false;
        [Required(ErrorMessage = "The field with quantity {0} is required")]
        public int Quantity { get; set; }
        public byte Thumnail { get; set; }
        [Required(ErrorMessage = "The field with warranty {0} is required")]
        public int Warranty { get; set; }
        public string Note { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }

        //Many relationship
        //public Nullable<Guid> CategoryId { get; set; }
        //public virtual Category Category { get; set; }

        //One relationship
        public virtual ICollection<SubCategoryDetail> SubCategoryDetails { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Feedback> Feebacks { get; set; }
    }
}
