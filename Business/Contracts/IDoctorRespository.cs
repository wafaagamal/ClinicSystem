using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IDoctorRespository:IRepository<Doctor>
    {
        void ResgisterDoctor(Doctor doctor);
        Doctor getByEmail(string email);
    }
}
