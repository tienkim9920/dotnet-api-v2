using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services.Admin
{
    public class ProductOptionService : IOptionProductRepository
    {
        private ComputerShopDBContext context;
        public ProductOptionService(ComputerShopDBContext context)
        {
            this.context = context;
        }
        public ProductOption AddProductOption(ProductOption productOption)
        {
            if (productOption == null) { throw new ArgumentNullException("Product Option"); }
            else
            {
                context.Add(productOption);
                context.SaveChanges();
                return productOption;
            }
        }

        public bool CheckExistProductOption(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductOption(Guid Id)
        {
            if (Id.ToString() != null)
            {
                context.Remove(context.ProductOption.Where(x => x.Id == Id));
                context.SaveChanges();
            }
            else { throw new Exception("Id is null"); }
        }

        public void EditProductOption(Guid Id, ProductOption productOption)
        {
            productOption.Modified_Date = new DateTime();
            var initial = context.ProductOption.FirstOrDefault(x => x.Id == Id);
            initial = productOption;
            if (productOption == null)
            {
                throw new Exception("Model is null");
            }
            context.Entry(initial).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<ProductOption> GetAllProductOption()
        {
            return context.ProductOption.ToList();
        }

        public ProductOption GetProductOptionByID(Guid Id)
        {
            if (Id.ToString() != null)
            {
                return context.ProductOption.FirstOrDefault(x => x.Id == Id);
            }
            else throw new Exception("Id is null");
        }
    }
}
