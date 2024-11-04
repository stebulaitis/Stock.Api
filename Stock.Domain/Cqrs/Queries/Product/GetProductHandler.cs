using AutoMapper;
using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Get;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Queries.Product
{
    public class GetProductHandler : IRequestHandler<GetProductRequestModel, GetProductResponseModel>
    {
        IProductService _productService;
        IMapper _mapper;

        public GetProductHandler(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<GetProductResponseModel> Handle(GetProductRequestModel request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByKey(request.Key);

            return product;
        }
    }
}
