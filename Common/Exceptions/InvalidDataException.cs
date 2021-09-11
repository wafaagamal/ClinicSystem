using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
   public class InvalidDataException: BaseException
    {
        public InvalidDataException(string message, string subject) : base(message, subject)
        {

        }
        public InvalidDataException(string message, string eNMessage, string subject) : base(message, eNMessage, subject)
        {
        }
    }
}
