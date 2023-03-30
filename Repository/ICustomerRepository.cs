using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomerByID(Guid Id);
        Customer AddCustomer(Customer customer);
        void EditCustomer(string Id, Customer customer);

        void DeleteCustomer(string Id);

        bool CheckExistCustomer(string Id);
    }
}
