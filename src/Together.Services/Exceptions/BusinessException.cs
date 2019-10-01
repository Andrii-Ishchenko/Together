using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.Conflict)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public override string Message { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}
