using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public virtual Secretary CreatedBy { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
