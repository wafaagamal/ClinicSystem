using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class AppointmentResultVM
    {
        public PatientVM Patient { set; get; }
        public ScheduleVM Schedule { set; get; }
    }
}
