using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Doctor :Employee
    {
        public virtual List<Schedule> Schedule { set; get; }
    }
}
