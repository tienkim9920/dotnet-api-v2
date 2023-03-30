using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Enum;
using Web_Api_Computer_Shop.Helper;
using Web_Api_Computer_Shop.Model;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services.Admin
{
    public class CategoryService : ICategoryRepository
    {
        private ComputerShopDBContext context;
        private readonly IHistoryLogRepository historyLogRepository;
        private readonly HistoryLogHelper<Category> historyLogHelper = new HistoryLogHelper<Category>();
        public CategoryService(ComputerShopDBContext context, IHistoryLogRepository historyLogRepository)
        {
            this.context = context;
            this.historyLogRepository = historyLogRepository;
        }
        public Category AddCategory(Category category, Guid IdUser)
        {
            category.Created_Date = DateTime.Now;
            if(category != null)
            {
                var a = context.Add(category);
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.ADD, null, category, ETypeTable.CATEGORY));
                context.SaveChanges();
                return context.Category.Where(x => x.Id == category.Id).FirstOrDefault();
            } else
            {
                var history = historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.ADD, ETypeTable.CATEGORY);
                historyLogRepository.AddHistoryLog(history);
                throw new Exception("Error");
            }
        }

        public bool CheckExistCategory(Guid Id)
        {
            var check = context.Category.FirstOrDefault(x => x.Id == Id);
            return check != null;
        }

        public void DeleteCategory(Guid Id, Guid IdUser)
        {
            var itemDelete = context.Category.FirstOrDefault(x => x.Id == Id);
            if (itemDelete != null)
            {
                context.Category.Remove(itemDelete);
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.Delete, itemDelete, null, ETypeTable.CATEGORY));
                context.SaveChanges();
            } else
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.Delete, ETypeTable.CATEGORY));
                throw new Exception("Id not exist");
            }
        }

        public void EditCategory(Guid Id, Guid IdUser, Category category)
        {
            category.Modified_Date = new DateTime();
            var initial = context.Category.FirstOrDefault(x=>x.Id == Id);
            initial = category;
            if (category == null)
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.UPDATE, ETypeTable.CATEGORY));
                throw new Exception("Model is null");
            }
            context.Entry(initial).State = EntityState.Modified;
            historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.UPDATE, category, null, ETypeTable.CATEGORY));
            context.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return context.Category.ToList();
        }

        public Category GetCategoryByID(Guid Id)
        {
            var category = context.Category.FirstOrDefault(x => x.Id == Id);
            if (category != null)
            {
                return category;
            }
            else throw new Exception("Id don't exist");
        }

        public PagedResponse<Category> GetAllCategoryPaging(PaginationQuery paginationQuery)
        {
            var data = context.Category.ToArray();
            var paginationHelper = new PaginationHelper<Category>();
            return paginationHelper.Pagination(data, paginationQuery.PageSize, paginationQuery.CurrentPage);
        }
    }
}
