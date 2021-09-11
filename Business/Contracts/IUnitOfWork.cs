using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IUnitOfWork
    {   
        IDoctorRespository doctorRespository { get;}
        ISecretaryRepository secretaryRepository { get; }
        IPatientRespository patientRespository { get; }
        IAppointmentRepository appointmentRepository { get; }
        ISchedualeRespository schedualeRespository { get; }
        IClinicRepository clinicRepository { get; }
        int Complete();
    }
}
