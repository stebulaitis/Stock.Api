namespace Stock.Core.Storage.Paginated
{
    public class PaginatedList<TEntity>
    {
        public PaginatedList(IEnumerable<TEntity> items, int total, int page, int pageSize)
        {
            Items = items;
            Total = total;
            Page = page;
            PageSize = pageSize;
        }

        public PaginatedList(IEnumerable<TEntity> items, int total, int pageSize)
        {
            Items = items;
            Total = total;
            PageSize = pageSize;
        }

        public IEnumerable<TEntity> Items { get; set; }

        public int Total { get; set; }

        public int TotalPages => (int)Math.Ceiling(Total / (double)PageSize);

        public int Page { get; set; }

        public int PageSize { get; set; }

        public PaginatedList<TEntity> SetCurrentPage(int remainingItems)
        {
            var totalRemainingPages = (int)Math.Ceiling(remainingItems / (double)PageSize);
            Page = (TotalPages - totalRemainingPages) + 1;

            return this;
        }
    }
}
