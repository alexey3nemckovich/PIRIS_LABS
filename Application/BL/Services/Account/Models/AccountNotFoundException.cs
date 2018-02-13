using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Common.Model;

namespace BL.Services.Account.Models
{
    public class AccountNotFoundException : ServiceException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
