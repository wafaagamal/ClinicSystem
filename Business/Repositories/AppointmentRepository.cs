using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        ClinicContext _db;
        public AppointmentRepository(ClinicContext context) : base(context)
        {
            _db = context;
        }

        public void add(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
        }
        public List<Appointment> getByDoctor(int docId)
        {

            return _db.Appointments.Include("Schedule").Include("Doctor").Include("Patient").AsEnumerable()
                .Where(a => a.Doctor.Id == docId && a.Doctor.IsActive && a.Schedule.Day == DateTime.Today.DayOfWeek).ToList();
        }
        public List<Appointment> getByDoctorwithRange(int docId, decimal from, decimal to, System.DayOfWeek day)
        {
            return _db.Appointments.Include("Schedule").Include("Doctor").Include("Patient")
                .Where(a => a.Doctor.Id == docId && a.Doctor.IsActive && a.Schedule.From >= from && a.Schedule.To <= to && a.Schedule.Day == day).ToList();
        }
        public Appointment getAppointmentByDoc_Patient_Schedule(int docId,int patId,int scheduleId)
        {
            return _db.Appointments.Include("Schedule").Include("Doctor").Include("Patient")
                .Where(a => a.Doctor.Id == docId && a.Patient.Id == patId && a.Schedule.Id == scheduleId).FirstOrDefault();
        }

    }
}
