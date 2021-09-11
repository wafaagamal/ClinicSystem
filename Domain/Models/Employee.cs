using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee :User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { set; get; }
        public virtual Clinic Clinic { set; get; }

    }
}
