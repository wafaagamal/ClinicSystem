using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repositories
{
    public class PatientRespository:Repository<Patient>, IPatientRespository
    {
        ClinicContext _db;
        public PatientRespository(ClinicContext context) : base(context)
        {
            _db = context;
        }
      
    }
}
