using System.Collections.Generic;

namespace Web_Api_Computer_Shop.Model
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }
        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }

        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int? TotalPage { get; set; }
    }
}
