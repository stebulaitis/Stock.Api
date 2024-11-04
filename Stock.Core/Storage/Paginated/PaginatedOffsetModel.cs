namespace Stock.Core.Storage.Paginated
{
    public class PaginatedOffsetModel
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
