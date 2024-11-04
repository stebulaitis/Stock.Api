using MediatR;

namespace Stock.Domain.Models.Product.Get
{
    public class GetProductsRequestModel : IRequest<GetProductsResponseModel>
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
