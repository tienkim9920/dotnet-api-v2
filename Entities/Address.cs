using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street_And_Apartment_Number { get; set; }
        public bool Default { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public Nullable<Guid> CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
