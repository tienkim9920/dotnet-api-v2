using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Model;

namespace Web_Api_Computer_Shop.Helper
{
    public class PaginationHelper<T>
    {
        public PagedResponse<T> Pagination(T[] data, int pageSize, int currentPage = 1)
        {
            var paged = new PagedResponse<T>();
            paged.Data = data
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList() as IEnumerable<T>;
            paged.TotalPage = (int)Math.Ceiling((decimal)data.Length / (decimal)pageSize);
            paged.PageSize = pageSize;
            paged.CurrentPage = currentPage;
            return paged;
        }
    }
}
