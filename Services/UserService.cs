using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services
{
    public class UserService : IUserReponsitory 
    {
        private List<User> _users;
        public UserService()
        {
            var userClass = new UserListTemp();
            _users = userClass.GetAll();
        }
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUsersByID(Guid ID)
        {
            return _users.FirstOrDefault(x => x.ID == ID);
        }

        public void AddUser(User User)
        {
            User.ID = Guid.NewGuid();
            _users.Add(User);
        }

        public void EditUser(string ID, User User)
        {
            _users[_users.FindIndex(x => x.ID == Guid.Parse(ID))].ID = Guid.Parse(ID);
            _users[_users.FindIndex(x => x.ID == Guid.Parse(ID))].Name = User.Name;
        }

        public void DeleteUser(string Id)
        {
            _users.RemoveAt(_users.FindIndex(x => x.ID == Guid.Parse(Id)));
        }

        public bool checkExistUser(string Id)
        {
            return _users.Exists(x=>x.ID == Guid.Parse(Id));
        }
    }
}
