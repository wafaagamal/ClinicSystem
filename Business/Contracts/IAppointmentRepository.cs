using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IAppointmentRepository :IRepository<Appointment>
    {
        void add(Appointment appointment);
        List<Appointment> getByDoctor(int docId);
        List<Appointment> getByDoctorwithRange(int docId, decimal from, decimal to, DayOfWeek day);
        Appointment getAppointmentByDoc_Patient_Schedule(int docId, int patId, int scheduleId);
    }
}
