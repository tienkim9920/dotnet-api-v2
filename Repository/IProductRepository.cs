using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        List<Product> AddMultiProduct(List<Product> products);
        List<Product> ImportCsv(IFormFile file);
        PagedResponse<Product> GetAllProductPaging(PaginationQuery paginationQuery);
        Product GetProductByID(Guid Id);
        void EditProduct(Guid Id, Product product);

        void DeleteProduct(Guid Id);
        void DeleteMultiProduct(List<Guid> Id);

        bool CheckExistProduct(Guid Id);

    }
}
