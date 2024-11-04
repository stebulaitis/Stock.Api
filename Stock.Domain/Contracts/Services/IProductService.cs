using Stock.Core.Storage.Paginated;
using Stock.Domain.Models.Product.Add;
using Stock.Domain.Models.Product.Get;
using Stock.Domain.Models.Product.Update;
using System;
using System.Threading.Tasks;

namespace Stock.Domain.Contracts.Services
{
    public interface IProductService
    {
        Task<AddProductResponseModel> Add(AddProductRequestModel productRequestModel);

        Task<GetProductsResponseModel> GetAll(PaginatedOffsetModel model);

        Task<GetProductResponseModel> GetByKey(Guid key);

        Task Update(UpdateProductRequestModel model);

        Task Delete(Guid key);
    }
}
