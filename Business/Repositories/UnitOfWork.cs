using Business.Contracts;
using Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext _db;
        public UnitOfWork(DBContext context)
        { 
        }
            public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
