using System;
using System.ComponentModel.DataAnnotations;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Model
{
    public class ProductFile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool Stock { get; set; } = false;
        public int Quantity { get; set; }
        public int Warranty { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public ProductOption productOption { get; set; }

    }
}
