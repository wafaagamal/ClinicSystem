using Business.Presentation;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Clinic.Models
{
    public class ViewModelDemo
    {
        public ScheduleVM Schedules { get; set; }
        public List<AppointmentResultVM> Appointments { get; set; }
        public List<DayOfWeek> Days { get; set; }
    }
}
