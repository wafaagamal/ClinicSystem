using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface ISchedualeRespository : IRepository<Schedule>
    {
        List<Schedule> GetScheduleByDoctorId(int docId);
        Schedule GetScheduleFromTo(decimal from, decimal to, DayOfWeek day);
    }
}
