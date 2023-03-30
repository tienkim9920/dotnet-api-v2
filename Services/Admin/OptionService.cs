using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services.Admin
{
    public class OptionService : IOptionRepository
    {
        private ComputerShopDBContext context;
        public OptionService(ComputerShopDBContext context)
        {
            this.context = context;
        }
        public Option AddOption(Option option)
        {
            if (option == null) { throw new ArgumentNullException("option"); }
            else
            {
                context.Option.Add(option);
                context.SaveChanges();
                return option;
            }
        }

        public bool CheckExistOption(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOption(Guid Id)
        {
            if (Id.ToString() != null)
            {
                context.Remove(context.Option.Where(x => x.Id == Id));
                context.SaveChanges();
            }
            else { throw new Exception("Id is null"); }
        }

        public void EditOption(Guid Id, Option option)
        {
            option.Modified_Date = new DateTime();
            var initial = context.Option.FirstOrDefault(x => x.Id == Id);
            initial = option;
            if (option == null)
            {
                throw new Exception("Model is null");
            }
            context.Entry(initial).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Option> GetAllOption()
        {
            return context.Option.ToList();
        }

        public Option GetOptionByID(Guid Id)
        {
            if(Id.ToString() != null)
            {
                return context.Option.FirstOrDefault(x => x.Id == Id);
            }
            else throw new Exception("Id is null");
        }
    }
}
