using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services
{
    public class CustomerService: ICustomerRepository
    {
        private ComputerShopDBContext context;
        public CustomerService(ComputerShopDBContext context)
        {
            this.context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
            return this.context.Customer.Find(customer.Id);
        }

        public bool CheckExistCustomer(string Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(string Id)
        {
            Customer customer = context.Customer.Where(x => x.Id == new Guid(Id)).FirstOrDefault();
            context.Customer.Remove(customer);
            context.SaveChanges();
        }

        public void EditCustomer(string Id, Customer customer)
        {
            var customerTemp = context.Customer.Find(Id);
            if (customerTemp != null)
            {
                customerTemp = customer;
                context.SaveChanges();
            }
        }

        public List<Customer> GetAllCustomer()
        {
            return context.Customer.ToList();
        }

        public Customer GetCustomerByID(Guid Id)
        {
            return context.Customer.Find(Id);
        }
    }
}
