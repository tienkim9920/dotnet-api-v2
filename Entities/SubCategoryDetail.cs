using System;
using Web_Api_Computer_Shop.Enum;

namespace Web_Api_Computer_Shop.Entities
{
    public class SubCategoryDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String detail { get; set; }
        //Many relationship
        public Nullable<Guid> SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        //Many relationship
        public Nullable<Guid> ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
