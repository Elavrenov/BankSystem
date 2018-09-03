using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.AccountServices
{
    public class AccountServiceException : Exception
    {
        public AccountServiceException()
        {
        }

        public AccountServiceException(string message) : base(message)
        {
        }

        public AccountServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
