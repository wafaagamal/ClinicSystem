using Business.Contracts;
using Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClinicContext _db;
        public IDoctorRespository doctorRespository { get; private set; }
        public ISecretaryRepository secretaryRepository { get; private set; }
        public IPatientRespository patientRespository { get; private set; }
        public IAppointmentRepository appointmentRepository { get; private set; }
        public ISchedualeRespository schedualeRespository { get; private set; }
        public IClinicRepository clinicRepository { get; private set; }
        public UnitOfWork(ClinicContext context)
        {
            doctorRespository = new DoctorRespository(context);
            secretaryRepository = new SecretaryRepository(context);
            patientRespository = new PatientRespository(context);
            appointmentRepository = new AppointmentRepository(context);
            schedualeRespository = new SchedualeRespository(context);
            clinicRepository = new ClinicRepository(context);
            _db = context;
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
