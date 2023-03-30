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
    public class SubCategoryService : ISubCategoryRepository
    {
        private ComputerShopDBContext context;
        private readonly IHistoryLogRepository historyLogRepository;
        private readonly HistoryLogHelper<SubCategory> historyLogHelper = new HistoryLogHelper<SubCategory>();
        public SubCategoryService(ComputerShopDBContext context, IHistoryLogRepository historyLogRepository)
        {
            this.context = context;
            this.historyLogRepository = historyLogRepository;
        }
        public SubCategory AddSubCategory(SubCategory subCategory, Guid IdUser)
        {
            var a = context.Add(subCategory);
            if (a != null)
            {
                context.SaveChanges();
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.ADD, null, subCategory, ETypeTable.SUB_CATEGORY));
                return context.SubCategory.Where(x => x.Id == subCategory.Id).FirstOrDefault();
            }
            else
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.ADD, ETypeTable.SUB_CATEGORY));
                throw new Exception("Error");
            }
        }

        public bool CheckExistSubCategory(Guid Id)
        {
            var check = context.SubCategory.FirstOrDefault(x => x.Id == Id);
            return check != null;
        }

        public void DeleteSubCategory(Guid Id, Guid IdUser)
        {
            var itemDelete = context.SubCategory.FirstOrDefault(x => x.Id == Id);
            if (itemDelete != null)
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.Delete, itemDelete, null, ETypeTable.SUB_CATEGORY));
                context.SubCategory.RemoveRange();
                context.SaveChanges();
            }
            else
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.Delete, ETypeTable.SUB_CATEGORY));
                throw new Exception("Id do not exist");
            }
        }

        public void EditSubCategory(Guid Id, Guid IdUser, SubCategory subCategory)
        {
            subCategory.Modified_Date = new DateTime();
            var initial = context.SubCategory.FirstOrDefault(x => x.Id == Id);
            initial = subCategory;
            if (subCategory == null)
            {
                historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLogError(IdUser, EAction.UPDATE, ETypeTable.SUB_CATEGORY));
                throw new Exception("Model is null");
            }
            context.Entry(initial).State = EntityState.Modified;
            historyLogRepository.AddHistoryLog(historyLogHelper.ExcutedSaveHistoryLog(IdUser, EAction.UPDATE, subCategory, null, ETypeTable.CATEGORY));
            context.SaveChanges();
        }

        public List<SubCategory> GetAllSubCategory()
        {
            return context.SubCategory.ToList();
        }

        public PagedResponse<SubCategory> GetAllSubCategoryPaging(PaginationQuery paginationQuery)
        {
            var data = context.SubCategory.ToArray();
            var paginationHelper = new PaginationHelper<SubCategory>();
            return paginationHelper.Pagination(data, paginationQuery.PageSize, paginationQuery.CurrentPage);
        }

        public List<SubCategory> GetListChildSubCategory(Guid Id)
        {
            var data = context.SubCategory.Where(x => x.SubCategoryParrentId == Id).ToArray();
            return data.ToList();
        }

        public List<SubCategory> GetListNotChildSubCategory()
        {
            var data = context.SubCategory.Where(x=> x.SubCategoryParrentId == null).ToArray();
            return data.ToList();
        }

        public SubCategory GetSubCategoryByID(Guid Id)
        {
            var subCategory = context.SubCategory.FirstOrDefault(x => x.Id == Id);
            if (subCategory != null)
            {
                return subCategory;
            }
            else throw new Exception("Id don't exist");
        }
    }
}
