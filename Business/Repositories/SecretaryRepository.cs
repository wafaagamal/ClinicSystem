using Business.Contracts;
using Domain.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repositories
{
    public class SecretaryRepository : Repository<Secretary>, ISecretaryRepository
    {
        ClinicContext _db;
        public SecretaryRepository (ClinicContext context):base(context)
        {
            _db = context;
        }
        public new Secretary Get(int id)
        {
            return _db.Secretaries.Where(d => d.Id == id && d.IsActive).FirstOrDefault();
        }
        public Secretary LoginSecretary(string email, string password)
        {
            return _db.Secretaries.Where(d => d.Email == email && d.Password == password).FirstOrDefault();

        }
        public void ResgisterSecretary(Secretary secretary)
        {
            _db.Secretaries.Add(secretary);

        }
        public Secretary getByEmail(string email)
        {
            return _db.Secretaries.Where(d => d.Email == email).FirstOrDefault();
        }
    }
}
