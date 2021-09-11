using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repositories
{
    public class DoctorRespository:Repository<Doctor>, IDoctorRespository
    {
        ClinicContext _db;
        public DoctorRespository(ClinicContext context) : base(context)
        {
            _db = context;
        }

        public new Doctor Get(int id)
        {
            return _db.Doctors.Where(d => d.Id == id && d.IsActive).FirstOrDefault();
        }

        public Doctor getByEmail(string email)
        {
            return _db.Doctors.Where(d => d.Email == email).FirstOrDefault();
        }

        public void ResgisterDoctor(Doctor doctor)
        {
             _db.Doctors.Add(doctor);
        }
    }
}
