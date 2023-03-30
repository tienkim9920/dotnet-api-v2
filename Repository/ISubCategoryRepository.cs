using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;

namespace Web_Api_Computer_Shop.Repository
{
    public interface ISubCategoryRepository
    {
        List<SubCategory> GetAllSubCategory();
        List<SubCategory> GetListNotChildSubCategory();
        List<SubCategory> GetListChildSubCategory(Guid Id);
        SubCategory GetSubCategoryByID(Guid Id);
        PagedResponse<SubCategory> GetAllSubCategoryPaging(PaginationQuery paginationQuery);
        SubCategory AddSubCategory(SubCategory subCategory, Guid IdUser);
        void EditSubCategory(Guid Id, Guid IdUser, SubCategory subCategory);

        void DeleteSubCategory(Guid Id, Guid IdUser);

        bool CheckExistSubCategory(Guid Id);
    }
}
