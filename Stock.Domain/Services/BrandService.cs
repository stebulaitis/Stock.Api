using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Storage.Paginated;
using Stock.Core.Validators;
using Stock.Domain.Contracts.Repositories;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Contracts.Storage;
using Stock.Domain.Entities;
using Stock.Domain.Models.Brand.Add;
using Stock.Domain.Models.Brand.Get;
using Stock.Domain.Models.Brand.Update;
using System;
using System.Threading.Tasks;

namespace Stock.Domain.Services
{
    public class BrandService(
        IBrandRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IDataValidator validator) : IBrandService
    {
        private readonly IBrandRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IDataValidator _validator = validator;

        public async Task<AddBrandResponseModel> Add(AddBrandRequestModel brandRequestModel)
        {
            var brand = _mapper.Map<Brand>(brandRequestModel);

            var brandDb = await _repository.AddAsync(brand);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<AddBrandResponseModel>(brandDb);
        }

        public async Task<GetBrandsResponseModel> GetAll(PaginatedOffsetModel model)
        {
            var brands = await _repository.GetPaginatedAsync<PaginatedList<Brand>>(d => d.Active, null, model.Page, model.PageSize, null, true);

            var brandsModel = _mapper.Map<GetBrandsResponseModel>(brands);

            return brandsModel;
        }

        public async Task<GetBrandResponseModel> GetByKey(Guid key)
        {
            var brand = await GetBrandByKey(key);

            var brandModel = _mapper.Map<GetBrandResponseModel>(brand);

            return brandModel;
        }

        public async Task Update(UpdateBrandRequestModel model)
        {
            var brand = await GetBrandByKey(model.Key);

            brand.Update(model.Name);

            _repository.Update(brand);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid key)
        {
            var brand = await GetBrandByKey(key);

            brand.SetStatus(false);

            _repository.Update(brand);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Brand> GetBrandByKey(Guid key)
        {
            var brand = await _repository.FirstOrDefaultAsync(d => d.Key.Equals(key) && d.Active, QueryTrackingBehavior.TrackAll);
            _validator.ThrowIfNull(brand, "Empresa não encontrada!");

            return brand;
        }
    }
}
