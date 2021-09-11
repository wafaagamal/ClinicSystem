using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class ScheduleVM
    {
        public int Id { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public DayOfWeek Day { get; set; }
        //public bool Checked { get; set; }
    }
}
