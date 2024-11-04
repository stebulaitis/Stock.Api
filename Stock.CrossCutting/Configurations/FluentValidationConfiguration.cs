using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Stock.Core.Models;
using Stock.Core.Validators;
using Stock.Domain.Contracts.Validators;
using Stock.Domain.Validators.Base;

namespace Stock.CrossCutting.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void AddApiFluentValidations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<IAssemblyModelsValidators>(ServiceLifetime.Transient);
            services.AddTransient<IFluentValidatorFactory, FluentValidatorFactory>();
            services.AddTransient<IDataValidator, DataValidator>();
            services.ConfigureResultErrors();
        }

        private static void ConfigureResultErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();

                    return new BadRequestObjectResult(new ErrorResponse(errors));
                };
            });
        }
    }
}
