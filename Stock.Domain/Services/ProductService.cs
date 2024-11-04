using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Storage.Paginated;
using Stock.Core.Validators;
using Stock.Domain.Contracts.Repositories;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Contracts.Storage;
using Stock.Domain.Entities;
using Stock.Domain.Models.Product.Add;
using Stock.Domain.Models.Product.Get;
using Stock.Domain.Models.Product.Update;
using System;
using System.Threading.Tasks;

namespace Stock.Domain.Services
{
    public class ProductService(
        IProductRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IDataValidator validator) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IDataValidator _validator = validator;

        public async Task<AddProductResponseModel> Add(AddProductRequestModel productRequestModel)
        {
            var product = _mapper.Map<Product>(productRequestModel);

            var productDb = await _repository.AddAsync(product);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<AddProductResponseModel>(productDb);
        }

        public async Task<GetProductsResponseModel> GetAll(PaginatedOffsetModel model)
        {
            var products = await _repository.GetPaginatedAsync<PaginatedList<Product>>(d => d.Active, null, model.Page, model.PageSize, null, true);

            var productsModel = _mapper.Map<GetProductsResponseModel>(products);

            return productsModel;
        }

        public async Task<GetProductResponseModel> GetByKey(Guid key)
        {
            var product = await GetProductByKey(key);

            var productModel = _mapper.Map<GetProductResponseModel>(product);

            return productModel;
        }

        public async Task Update(UpdateProductRequestModel model)
        {
            var product = await GetProductByKey(model.Key);

            product.Update(model.Name);

            _repository.Update(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid key)
        {
            var product = await GetProductByKey(key);

            product.SetInactive();

            _repository.Update(product);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Product> GetProductByKey(Guid key)
        {
            var product = await _repository.FirstOrDefaultAsync(d => d.Key.Equals(key) && d.Active, QueryTrackingBehavior.TrackAll);
            _validator.ThrowIfNull(product, "Produto não encontrado!");

            return product;
        }
    }
}
