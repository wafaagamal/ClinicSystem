using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contexts
{
    public class ClinicContext :DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> option) : base(option)
        {
        }
        public virtual DbSet<Clinic> Clinic { set; get; }
        public virtual DbSet<Doctor> Doctors { set; get; }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Appointment> Appointments { set; get; }
        public virtual DbSet<Patient> Patients { set; get; }
        public virtual DbSet<Secretary> Secretaries { set; get; }
        public virtual DbSet<Schedule> Schedules { set; get; }
        public virtual DbSet<User> Users { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Address = "new cairo",
                    age = 30,
                    BirthDate = DateTime.Parse("10/8/1988"),
                    CreatedAt = DateTime.Now,
                    UserName = "sara ahmed",
                    MobileNumber = "01036547894",
                    Id = 1
                });
            modelBuilder.Entity<Clinic>().HasData(
                  new Clinic
                  {
                      CreatedAt = DateTime.Now,
                      Name = "beauty Clinc",
                      Address = "new cairo",
                      Id = 1
                  });

        }
    }

}
