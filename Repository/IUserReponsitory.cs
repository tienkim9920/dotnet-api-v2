using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IUserReponsitory
    {
        List<User> GetAllUsers();
        User GetUsersByID(Guid Id);
        void AddUser(User user);
        void EditUser(string Id, User user);

        void DeleteUser(string Id);

        bool checkExistUser(string Id);
    }
}