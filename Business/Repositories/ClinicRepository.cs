using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public class ClinicRepository : Repository<Clinic>, IClinicRepository
    {
        ClinicContext _db;
        public ClinicRepository(ClinicContext context) : base(context)
        {
            _db = context;
        }
    }
}
