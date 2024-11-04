using FluentValidation;

namespace Stock.Core.Validators;

public interface IFluentValidatorFactory
{
    IValidator<TModel> GetValidator<TModel>();
}
