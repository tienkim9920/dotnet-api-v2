using System;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByID(Guid Id);
    }
}
