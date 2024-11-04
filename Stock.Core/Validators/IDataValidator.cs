namespace Stock.Core.Validators;

public interface IDataValidator
{
    Task<bool> IsValid<TModel>(TModel model)
        where TModel : new();

    void ThrowIfNull<TModel>([ValidatedNotNull]  TModel model, string message, params object[] args)
        where TModel : new();

    void ThrowIfStringNotEqual(string strA, string strB, string message, params object[] args);

    void ThrowIfStringIsNullOrEmpty(string strA, string message, params object[] args);

    void ThrowIfLessThanOrEqualTo(int targetValue, int value, string message, params object[] args);
}
