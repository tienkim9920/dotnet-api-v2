using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services.Admin
{
    public class ProductService : IProductRepository
    {
        private ComputerShopDBContext context;
        private readonly IHistoryLogRepository historyLogRepository;
        private readonly GetIdCurrentUserHelper getIdCurrentUserHelper = new GetIdCurrentUserHelper();
        public ProductService(ComputerShopDBContext context, IHistoryLogRepository historyLogRepository)
        {
            this.context = context;
            this.historyLogRepository = historyLogRepository;
        }
        public Product AddCustomer(Product product)
        {
            if(product == null)
            {
                throw new Exception("Product is null");
            }
            else
            {
                context.Product.Add(product);
                context.SaveChanges();
                return product;
            }
        }
        public List<Product> AddMultiProduct(List<Product> products)
        {
            if (products == null)
            {
                throw new Exception("List product is null");
            }
            else
            {
                products.ForEach(product => { product.Created_Date = new DateTime(); });
                context.AddRange(products);
                context.SaveChanges();
                return products;
            }
        }
        public PagedResponse<Product> GetAllProductPaging(PaginationQuery paginationQuery)
        {
            var data = context.Product.ToArray();
            var paginationHelper = new PaginationHelper<Product>();
            return paginationHelper.Pagination(data, paginationQuery.PageSize, paginationQuery.CurrentPage);
        }

        bool IProductRepository.CheckExistProduct(Guid Id)
        {
            if (!context.Product.Any()) { return false; }
            else return true;
        }

        void IProductRepository.DeleteProduct(Guid Id)
        {
            if (Id.ToString() != null)
            {
                context.RemoveRange(context.Product.Where(x => x.Id == Id));
                context.SaveChanges();
            }
            else { throw new Exception("Id is null"); }
        }

        void IProductRepository.DeleteMultiProduct(List<Guid> Ids)
        {
            if (Ids != null)
            {
                context.RemoveRange(context.Product.Where(x => Ids.Contains(x.Id)));
            }
            else { throw new Exception("List Id is null"); }
        }

        void IProductRepository.EditProduct(Guid Id, Product product)
        {
            product.Modified_Date = new DateTime();
            var initial = context.Product.FirstOrDefault(x => x.Id == Id);
            initial = product;
            if (product == null)
            {
                throw new Exception("Model is null");
            }
            context.Entry(initial).State = EntityState.Modified;
            context.SaveChanges();
        }

        List<Product> IProductRepository.GetAllProduct()
        {
            return context.Product.ToList();
        }
        public Product GetProductByID(Guid Id)
        {
            if (Id.ToString() != null)
            {
                return context.Product.FirstOrDefault(x => x.Id == Id);
            }
            else throw new Exception("Id is null");
        }


        List<Product> IProductRepository.ImportCsv(IFormFile file)
        {
            return null;
            //if (file != null)
            //{
            //    var fileextension = Path.GetExtension(file.FileName);
            //    var filename = Guid.NewGuid().ToString() + fileextension;
            //    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);
            //    using (FileStream fs = System.IO.File.Create(filepath))
            //    {
            //        file.CopyTo(fs);
            //    }
            //    if (fileextension == ".csv")
            //    {
            //        using (var reader = new StreamReader(filepath))
            //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //        {
            //            var records = csv.GetRecords<FileInfo>();
            //            foreach (var record in records)
            //            {

            //                if (string.IsNullOrWhiteSpace(record.Name))
            //                {
            //                    break;
            //                }
            //                ProductFile productFile;
            //                productFile = context.Product.Where(s => s.Name == record.Name).FirstOrDefault();

            //                if (productFile == null)
            //                {
            //                    productFile = new ProductFile();
            //                }

            //                student.Name = record.Name;
            //                student.Class = record.Class;
            //                student.Roll_No = record.StateWebsite;

            //                if (student.Id == Guid.Empty)
            //                    context.Studnets.Add(student);
            //                else
            //                    context.Students.Update(student);
            //            }
            //            context.SaveChanges();
            //        }
            //    }
            //    else
            //    {
            //        return new ResponseViewModel<object>
            //        {
            //            Status = false,
            //            Message = "You can onlu add CSV file",
            //            StatusCode = System.Net.HttpStatusCode.unprocessableentiy.ToString()
            //        };
            //    }
            //        return new ResponseViewModel<object>
            //        {
            //            Status = true,
            //            Message = "Data Updated Successfully",
            //            StatusCode = System.Net.HttpStatusCode.OK.ToString()
            //        };

            //    }
            //}
        }
    }
}
