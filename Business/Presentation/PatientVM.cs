using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class PatientVM
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public int age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
