using AutoMapper;
using MediatR;
using Stock.Core.Storage.Paginated;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Get;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Queries.Product
{
    public class GetAllProductHandler : IRequestHandler<GetProductsRequestModel, GetProductsResponseModel>
    {
        IProductService _productService;
        IMapper _mapper;

        public GetAllProductHandler(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<GetProductsResponseModel> Handle(GetProductsRequestModel request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<PaginatedOffsetModel>(request);

            var product = await _productService.GetAll(query);

            return product;
        }
    }
}
