using System.Collections.Generic;

namespace Stock.Domain.Models.Brand.Get
{
    public class GetBrandsResponseModel
    {
        public int Total { get; set; }

        public int TotalPages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<GetBrandResponseModel> Brands { get; set; }
    }
}
