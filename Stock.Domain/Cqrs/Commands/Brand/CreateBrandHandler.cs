using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Brand.Add;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Commands.Brand
{
    public class CreateBrandHandler(IBrandService brandService) : IRequestHandler<AddBrandRequestModel, AddBrandResponseModel>
    {
        readonly IBrandService _brandService = brandService;

        public async Task<AddBrandResponseModel> Handle(AddBrandRequestModel command, CancellationToken cancellationToken)
        {
            var brand = await _brandService.Add(command);

            return brand;
        }
    }
}
