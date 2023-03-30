using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Pay_Type { get; set; }
        public string Card_Id { get; set; }
        public string CCV { get; set; }
        public string Valid_Date { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Nullable<Guid> CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
