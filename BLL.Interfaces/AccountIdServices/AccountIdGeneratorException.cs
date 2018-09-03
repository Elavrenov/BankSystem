using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.AccountIdServices
{
    public class AccountIdGeneratorException : Exception
    {
        public AccountIdGeneratorException()
        {
        }

        public AccountIdGeneratorException(string message) : base(message)
        {
        }

        public AccountIdGeneratorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountIdGeneratorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
