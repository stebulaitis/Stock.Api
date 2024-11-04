using System.Runtime.Serialization;

namespace Stock.Core.Exceptions
{
    public class DomainValidationException : Exception
    {
        private readonly ICollection<string> _errorMessages;

        public DomainValidationException()
        {
            _errorMessages = new List<string>();
        }

        public DomainValidationException(ICollection<string> messages)
            : base()
        {
            _errorMessages = messages;
        }

        public DomainValidationException(string message)
            : base(message)
        {
            _errorMessages = new List<string>
            {
                message
            };
        }

        public DomainValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DomainValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ICollection<string> ErrorMessages => _errorMessages;
    }
}
