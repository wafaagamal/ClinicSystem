using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class AlreadyExistsException : BaseException
    {
        public AlreadyExistsException(string message, string subject) : base(message, subject)
        {
        }
        public AlreadyExistsException(string message, string eNMessage, string subject) : base(message, eNMessage, subject)
        {
        }
  
    }
}
