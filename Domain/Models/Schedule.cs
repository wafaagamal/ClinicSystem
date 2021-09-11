using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public DayOfWeek Day { get; set; }
        public bool Checked { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
