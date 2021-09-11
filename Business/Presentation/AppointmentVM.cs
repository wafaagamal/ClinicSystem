using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class AppointmentVM
    {
        public  DoctorVM Doctor { set; get; }
        public  PatientVM Patient { set; get; }
        public  ScheduleVM Schedule { set; get; }
    }
}
