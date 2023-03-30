using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public virtual ICollection<OrderSupplier> OrderSuppliers { get; set; }
        public Guid Account_Id { get; set; }
        public virtual Account Account { get; set; }
    }
}
