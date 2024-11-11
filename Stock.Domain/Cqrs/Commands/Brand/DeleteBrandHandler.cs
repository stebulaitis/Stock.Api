using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Brand.Delete;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Brand
{
    public class DeleteBrandHandler(IBrandService brandService) : IRequestHandler<DeleteBrandRequestModel, Unit>
    {
        readonly IBrandService _brandService = brandService;

        public async Task<Unit> Handle(DeleteBrandRequestModel command, CancellationToken cancellationToken)
        {
            await _brandService.Delete(command.Key);

            return Unit.Value;
        }
    }
}
