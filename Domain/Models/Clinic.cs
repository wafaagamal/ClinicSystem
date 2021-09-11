using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public  class Clinic
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
