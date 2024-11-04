using FluentValidation;
using Stock.Core.Exceptions;
using Stock.Core.Validators;
using System.Threading.Tasks;

namespace Stock.Domain.Validators.Base
{
    public class DataValidator : IDataValidator
    {
        private readonly IFluentValidatorFactory _fluentValidatorFactory;

        public DataValidator(
            IFluentValidatorFactory fluentValidatorFactory)
        {
            _fluentValidatorFactory = fluentValidatorFactory;
        }

        public async Task<bool> IsValid<TModel>(TModel model)
            where TModel : new()
        {
            var validator = GetValidatorInstance<TModel>();
            if (validator is null)
            {
                return await Task.FromResult(true);
            }

            var validationResult = await validator.ValidateAsync(model);
            return validationResult.IsValid;
        }

        public void ThrowIfStringNotEqual(string strA, string strB, string message, params object[] args)
        {
            if (!string.Equals(strA, strB))
            {
                throw new DomainException(message);
            }
        }

        public void ThrowIfNull<TModel>([ValidatedNotNull] TModel model, string message, params object[] args)
            where TModel : new()
        {
            if (model is null)
            {
                throw new DomainNotFoundException(message);
            }
        }

        public void ThrowIfStringIsNullOrEmpty(string strA, string message, params object[] args)
        {
            if (string.IsNullOrEmpty(strA))
            {
                throw new DomainException(message);
            }
        }

        public void ThrowIfLessThanOrEqualTo(int targetValue, int value, string message, params object[] args)
        {
            if (value <= targetValue)
            {
                throw new DomainException(message);
            }
        }

        private IValidator<TModel> GetValidatorInstance<TModel>()
        {
            return _fluentValidatorFactory.GetValidator<TModel>();
        }
    }
}
