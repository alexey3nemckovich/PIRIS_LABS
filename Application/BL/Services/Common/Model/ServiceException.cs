using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Common.Model
{
    [Serializable]
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
