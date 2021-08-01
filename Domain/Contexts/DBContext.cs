using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contexts
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> option) : base(option)
        {
        }
    }
}
