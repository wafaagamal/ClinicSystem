using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message, string subject) : base(message, subject)
        {

        }
        public NotFoundException(string message, string eNMessage, string subject) : base(message, eNMessage, subject)
        {
        }
    }
}
