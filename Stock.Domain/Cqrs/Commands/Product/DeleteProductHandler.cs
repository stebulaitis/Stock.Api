using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Delete;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Product
{
    public class DeleteProductHandler(IProductService productService) : IRequestHandler<DeleteProductRequestModel, Unit>
    {
        readonly IProductService _productService = productService;

        public async Task<Unit> Handle(DeleteProductRequestModel command, CancellationToken cancellationToken)
        {
            await _productService.Delete(command.Key);

            return Unit.Value;
        }
    }
}
