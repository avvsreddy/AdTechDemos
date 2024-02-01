using System.Runtime.Serialization;

namespace SimpleBank.Business
{
    [Serializable]
    public class InsufficcientBalanceException : ApplicationException
    {
        public InsufficcientBalanceException()
        {
        }

        public InsufficcientBalanceException(string message) : base(message)
        {
        }

        public InsufficcientBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficcientBalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}