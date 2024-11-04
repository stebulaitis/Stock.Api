namespace Stock.Core.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message ?? string.Empty)
        {
        }
    }
}
