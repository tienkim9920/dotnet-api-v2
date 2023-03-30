using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IOptionProductRepository
    {
        List<ProductOption> GetAllProductOption();
        ProductOption GetProductOptionByID(Guid Id);
        ProductOption AddProductOption(ProductOption productOption);
        void EditProductOption(Guid Id, ProductOption productOption);
        void DeleteProductOption(Guid Id);
        bool CheckExistProductOption(Guid Id);
    }
}
