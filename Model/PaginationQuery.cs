namespace Web_Api_Computer_Shop.Model
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            CurrentPage = 1;
            PageSize = 10;
        }
        public PaginationQuery(int currentNumber, int pageSize)
        {
            CurrentPage = currentNumber;
            PageSize = pageSize;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
