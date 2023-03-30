using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Nullable<Guid> ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Nullable<Guid> OrderSupplierId { get; set; }
        public virtual OrderSupplier OrderSupplier { get; set; }
    }
}
