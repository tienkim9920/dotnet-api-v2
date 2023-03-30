using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Nullable<Guid> ProductId { get; set; }
        public Nullable<Guid> CustomerId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
