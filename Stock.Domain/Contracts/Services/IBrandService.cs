using Stock.Core.Storage.Paginated;
using Stock.Domain.Models.Brand.Add;
using Stock.Domain.Models.Brand.Get;
using Stock.Domain.Models.Brand.Update;
using System;
using System.Threading.Tasks;

namespace Stock.Domain.Contracts.Services
{
    public interface IBrandService
    {
        Task<AddBrandResponseModel> Add(AddBrandRequestModel brandRequestModel);

        Task<GetBrandsResponseModel> GetAll(PaginatedOffsetModel model);

        Task<GetBrandResponseModel> GetByKey(Guid key);

        Task Update(UpdateBrandRequestModel model);

        Task Delete(Guid key);
    }
}
