using System;
using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;

namespace Web_Api_Computer_Shop.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategoryByID(Guid Id);
        Category AddCategory(Category category, Guid IdUser);
        void EditCategory(Guid Id, Guid IdUser, Category category);
        PagedResponse<Category> GetAllCategoryPaging(PaginationQuery paginationQuery);

        void DeleteCategory(Guid Id, Guid IdUser);

        bool CheckExistCategory(Guid Id);
    }
}
