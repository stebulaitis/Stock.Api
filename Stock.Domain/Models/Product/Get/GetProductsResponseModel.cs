using System.Collections.Generic;

namespace Stock.Domain.Models.Product.Get
{
    public class GetProductsResponseModel
    {
        public int Total { get; set; }

        public int TotalPages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<GetProductResponseModel> Products { get; set; }
    }
}
