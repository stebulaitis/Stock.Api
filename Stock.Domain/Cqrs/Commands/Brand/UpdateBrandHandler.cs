using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Brand.Update;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Brand
{
    public class UpdateBrandHandler(IBrandService brandService) : IRequestHandler<UpdateBrandRequestModel, Unit>
    {
        readonly IBrandService _brandService = brandService;

        public async Task<Unit> Handle(UpdateBrandRequestModel command, CancellationToken cancellationToken)
        {
            await _brandService.Update(command);

            return Unit.Value;
        }
    }
}
