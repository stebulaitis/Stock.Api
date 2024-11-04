using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Data.SqlServer.Repositories;
using Stock.Data.SqlServer.Repositories.Base;
using Stock.Data.SqlServer.UnitOfWork;
using Stock.Domain.Contracts.Cqrs;
using Stock.Domain.Contracts.Repositories;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Contracts.Storage;
using Stock.Domain.Profiles;
using Stock.Domain.Services;

namespace Stock.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            //AutoMapper
            services.AddAutoMapper(
                typeof(ProductProfile).Assembly);

            //Services
            services.AddScoped<IProductService, ProductService>();

            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWorkStock>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //Cqrs
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(IDomainAssembly).Assembly));
        }
    }
}
