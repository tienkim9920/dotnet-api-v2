using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Invoice_Buy_No { get; set; }
        public double Amount { get; set; }
        public string Fee_Ship { get; set; }
        public string Status { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public double Disccount { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Nullable<Guid> CustomerId { get; set; }
        public Nullable<Guid> PaymentId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        //one relationship
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
