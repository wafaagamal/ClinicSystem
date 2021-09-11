using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Patient:User
    {

        public int age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
