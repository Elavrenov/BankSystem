using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public class AccountRepositoryException : Exception
    {
        public AccountRepositoryException()
        {
        }

        public AccountRepositoryException(string message) : base(message)
        {
        }

        public AccountRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
