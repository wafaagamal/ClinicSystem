using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class BaseException : Exception
    {
        public string Subject { private set; get; }
        public string ENMessage { private set; get; }
        public HttpStatusCode StatusCode { private set; get; }
        public BaseException(string message, string subject) : base(message)
        {
            Subject = subject;
        }
        public BaseException(string message, string enMessage, string subject) : base(message)
        {
               ENMessage = enMessage;
               Subject = subject;
        }
        public BaseException(HttpStatusCode statusCode, string message, string subject) : base(message)
        {
            StatusCode = statusCode;
            Subject = subject;
        }
    }
}
