namespace CompanyBranchAPI.Helper
{
    public class PagedResult<T>
    {
        
            public IEnumerable<T> Items { get; set; } = new List<T>();
            public int TotalCount { get; set; }
            public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }

            public PagedResult(IEnumerable<T> items, int totalCount, int currentPage, int pageSize)
            {
                Items = items;
                TotalCount = totalCount;
                CurrentPage = currentPage;
                PageSize = pageSize;
            }
        

    }
}
