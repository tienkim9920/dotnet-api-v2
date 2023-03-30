using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class ProductOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String detail { get; set; }
        //public Nullable<Guid> ProductId { get; set; }
        //public virtual Product Product { get; set; }
        //public Nullable<Guid> OptionId { get; set; }
        //public virtual Option Option { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
