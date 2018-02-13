using System;
using System.Runtime.Serialization;
using BL.Services.Common.Model;

namespace BL.Services.Transaction.Models
{
    [Serializable]
    public class InsufficientFundsException : ServiceException
    {
        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
