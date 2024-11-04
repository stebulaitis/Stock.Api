using FluentValidation;

namespace Stock.Core.Validators
{
    public class FluentValidatorFactory : IFluentValidatorFactory
    {
        private readonly IServiceProvider _provider;

        public FluentValidatorFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IValidator<TModel> GetValidator<TModel>()
        {
            var genericType = typeof(IValidator<>).MakeGenericType(typeof(TModel));
            return (IValidator<TModel>)_provider.GetService(genericType);
        }
    }
}
