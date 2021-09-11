using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
  public  class GeneralErrorResponse
    {
        public float ErrorCode { set; get; }
        public List<GeneralErrorDetailsResponse> Details { set; get; }
    }
}
