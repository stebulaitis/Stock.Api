using AutoMapper;
using Stock.Core.Storage.Paginated;
using Stock.Domain.Entities;
using Stock.Domain.Models.Product.Add;
using Stock.Domain.Models.Product.Get;

namespace Stock.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            #region Product - Add

            CreateMap<AddProductRequestModel, Product>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Name));

            CreateMap<Product, AddProductResponseModel>()
                .ForMember(d => d.Key, s => s.MapFrom(x =>x.Key));

            #endregion Product - Add

            #region Product - Get

            CreateMap<GetProductsRequestModel, PaginatedOffsetModel>();

            CreateMap<PaginatedList<Product>, GetProductsResponseModel>()
                .ForMember(d => d.Products, s => s.MapFrom(x => x.Items));

            CreateMap<Product, GetProductResponseModel>();

            #endregion Product - Get
        }
    }
}
