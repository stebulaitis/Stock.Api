namespace Stock.Core.Exceptions
{
    [Serializable]
    public class DomainNotFoundException : Exception
    {
        public DomainNotFoundException()
        {
        }

        public DomainNotFoundException(string message)
            : base(message ?? string.Empty)
        {
        }
    }
}
