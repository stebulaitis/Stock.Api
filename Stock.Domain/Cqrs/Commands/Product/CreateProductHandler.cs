using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Add;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Product
{
    public class CreateProductHandler(IProductService productService) : IRequestHandler<AddProductRequestModel, AddProductResponseModel>
    {
        readonly IProductService _productService = productService;

        public async Task<AddProductResponseModel> Handle(AddProductRequestModel command, CancellationToken cancellationToken)
        {
            var product = await _productService.Add(command);

            return product;
        }
    }
}
