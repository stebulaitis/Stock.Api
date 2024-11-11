using AutoMapper;
using MediatR;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Brand.Get;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Queries.Brand
{
    public class GetBrandHandler : IRequestHandler<GetBrandRequestModel, GetBrandResponseModel>
    {
        IBrandService _brandService;
        IMapper _mapper;

        public GetBrandHandler(
            IBrandService brandService,
            IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        public async Task<GetBrandResponseModel> Handle(GetBrandRequestModel request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.GetByKey(request.Key);

            return brand;
        }
    }
}
