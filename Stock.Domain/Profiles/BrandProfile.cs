using AutoMapper;
using Stock.Core.Storage.Paginated;
using Stock.Domain.Entities;
using Stock.Domain.Models.Brand.Add;
using Stock.Domain.Models.Brand.Get;

namespace Stock.Domain.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            #region Brand - Add

            CreateMap<AddBrandRequestModel, Brand>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Name));

            CreateMap<Brand, AddBrandResponseModel>()
                .ForMember(d => d.Key, s => s.MapFrom(x => x.Key));

            #endregion Brand - Add

            #region Brand - Get

            CreateMap<GetBrandsRequestModel, PaginatedOffsetModel>();

            CreateMap<PaginatedList<Brand>, GetBrandsResponseModel>()
                .ForMember(d => d.Brands, s => s.MapFrom(x => x.Items));

            CreateMap<Brand, GetBrandResponseModel>();

            #endregion Brand - Get
        }
    }
}
