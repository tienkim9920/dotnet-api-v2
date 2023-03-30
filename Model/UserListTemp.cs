using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Model
{
    public class UserListTemp
    {
        public List<User> GetAll()
        {
            var users = new List<User>()
            {
                new User(){
                    ID = Guid.Parse("49f974f0-5b9e-4a51-b64d-e9551d41b5d3"),
                    Name = "Comedy",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = true,
                    UserName = "nguyen",
                    PassWord = "123",
                },
                new User(){
                    ID = Guid.Parse("99d45681-c74d-4966-bfb2-22a589f36e20"),
                    Name = "Jack",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("3350fd6c-15ed-4a2d-a716-4b1bacd8ce02"),
                    Name = "William",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("1fba3fd8-acaa-49a0-b980-71ae08de6a48"),
                    Name = "Jame",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("2f2d2269-10c6-43c1-8b6f-9b74f19ed1f8"),
                    Name = "John",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("f5fa45a8-8ae0-478d-9bb2-bc8511857e60"),
                    Name = "Rooney",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("ab43097e-fa42-4885-93de-fc4edb6c181a"),
                    Name = "Ronaldo",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("b479c9eb-4c6c-4dcc-9401-66181c7fa46c"),
                    Name = "James",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("b3850524-3101-4120-81ce-43bb07c2571d"),
                    Name = "Coutinho",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                },
                new User(){
                    ID = Guid.Parse("0479aec4-fa91-4a0a-b9cf-3a49c04d61df"),
                    Name = "Foden",
                    DateOfBirth = DateTime.Now,
                    Gender = false,
                    IsAdmin = false,
                    UserName = "",
                    PassWord = "",
                }
            };
            return users;
        }
    }
}
