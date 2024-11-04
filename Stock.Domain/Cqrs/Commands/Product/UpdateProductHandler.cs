using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Update;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Product
{
    public class UpdateProductHandler(IProductService productService) : IRequestHandler<UpdateProductRequestModel, Unit>
    {
        readonly IProductService _productService = productService;

        public async Task<Unit> Handle(UpdateProductRequestModel command, CancellationToken cancellationToken)
        {
            await _productService.Update(command);

            return Unit.Value;
        }
    }
}
