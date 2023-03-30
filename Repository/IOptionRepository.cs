using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IOptionRepository
    {
        List<Option> GetAllOption();
        Option GetOptionByID(Guid Id);
        Option AddOption(Option option);
        void EditOption(Guid Id, Option option);
        void DeleteOption(Guid Id);
        bool CheckExistOption(Guid Id);
    }
}
