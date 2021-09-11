using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message, string subject) : base(message, subject)
        {
        }
        public BadRequestException(string message, string eNMessage, string subject) : base(message, eNMessage, subject)
        {
        }
    }
}
