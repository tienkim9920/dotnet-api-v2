using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class OrderSupplier
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Total { get; set; }
        public string Invoice_No { get; set; }
        public string Payment_Status { get; set; }
        public string Debt { get; set; }
        public string Payment_Amount { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        //One relationship
        public virtual ICollection<Transaction> Transactions { get; set; }
        public Nullable<Guid> SupplierId { get; set; }
        public Nullable<Guid> EmployeeId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
