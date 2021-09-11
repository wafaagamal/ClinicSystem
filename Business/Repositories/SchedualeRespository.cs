using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repositories
{
    public class SchedualeRespository : Repository<Schedule>, ISchedualeRespository
    {
        ClinicContext _db;
        public SchedualeRespository(ClinicContext context) : base(context)
        {
            _db = context;
        }
        public List<Schedule> GetScheduleByDoctorId(int docId)
        {
            return _db.Schedules.Where(s => s.Doctor.Id == docId && s.Doctor.IsActive &&s.Checked==false).ToList();
        }
        public Schedule GetScheduleFromTo(decimal from ,decimal to, DayOfWeek day)
        {
            return _db.Schedules.Where(s => s.From == from && s.To == to && s.Day == day && !s.Checked).FirstOrDefault();
        }
    }
}
