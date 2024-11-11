using AutoMapper;
using MediatR;
using Stock.Core.Storage.Paginated;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Brand.Get;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Cqrs.Queries.Brand
{
    public class GetAllBrandHandler : IRequestHandler<GetBrandsRequestModel, GetBrandsResponseModel>
    {
        IBrandService _brandService;
        IMapper _mapper;

        public GetAllBrandHandler(
            IBrandService brandService,
            IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        public async Task<GetBrandsResponseModel> Handle(GetBrandsRequestModel request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<PaginatedOffsetModel>(request);

            var brand = await _brandService.GetAll(query);

            return brand;
        }
    }
}
