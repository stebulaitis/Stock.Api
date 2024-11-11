using MediatR;

namespace Stock.Domain.Models.Brand.Get
{
    public class GetBrandsRequestModel : IRequest<GetBrandsResponseModel>
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
