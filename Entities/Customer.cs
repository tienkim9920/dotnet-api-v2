using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Computer_Shop.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [StringLength(100)]
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string Full_Name { get; set; }
        [StringLength(12)]
        [Required(ErrorMessage = "The field with phone {0} is required")]
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Birthday { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Feedback> Feebacks { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual Account Account { get; set; }
        public Guid Account_Id { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
