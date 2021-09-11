using Business.Contracts;
using Business.Presentation;
using Common.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic.SecretaryBL
{
    public class SecretaryLogic
    {
        IUnitOfWork worker;
        public SecretaryLogic(IUnitOfWork work)
        {
            worker = work;
        }

        private SecretaryVM ConvertVM(Secretary secretary)
        {
            return new SecretaryVM
            {
                UserName = secretary.UserName,
                IsActive = secretary.IsActive,
                MobileNumber = secretary.MobileNumber,
                Email = secretary.Email,
                Id = secretary.Id
            };
        }
        private List<SecretaryVM> ConvertVMs(List<Secretary> secretaries)
        {
            List<SecretaryVM>  secretariesVM = new List<SecretaryVM>();
            foreach (var doc in secretaries)
            {
                secretariesVM.Add(ConvertVM(doc));
            }
            return secretariesVM;
        }

        public void MakeAppointment(int DoctorId,int ScheduleId,int PatientId)
        {
            if(DoctorId<=0)
                throw new BadRequestException("Invalid Doctor Id ", "Invalid Data");
            if (PatientId<=0)
                throw new BadRequestException("Invalid Patient Id ", "Invalid Data");
            if (ScheduleId <=0)
                throw new BadRequestException("Invalid Time ", "Invalid Data");
          
            var patient = worker.patientRespository.Get(PatientId);
            if (patient == null)
                throw new NotFoundException("Patient Doesn't Exist", "Not Found");
            
            var doctor = worker.doctorRespository.Get(DoctorId);
            if (doctor == null)
                throw new NotFoundException("Doctor Doesn't Exist", "Not Found");

            var schedule = worker.schedualeRespository.Get(ScheduleId);
            if (schedule == null || schedule.Checked || (int)schedule.Day< DateTime.Today.Day)
                throw new NotFoundException("Time is not Available", "Not Found");
      
            var _appoint = worker.appointmentRepository.getAppointmentByDoc_Patient_Schedule(patient.Id,doctor.Id,schedule.Id);
            if (_appoint != null)
                throw new InvalidDataException("This Appointment is already Taken", "Invalid Data");

            schedule.Checked = true;
            var appoint = new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                Schedule =schedule
            };
            worker.appointmentRepository.add(appoint);
            worker.Complete();
  
        }

        public void Register(RegisterViewModel register)
        {
            if (register == null)
                throw new BadRequestException("Invalid doctor data", "Invalid Data");
            if (String.IsNullOrEmpty(register.Email))
                throw new BadRequestException("Invalid Email", "Invalid Data");
            if (String.IsNullOrEmpty(register.UserName))
                throw new BadRequestException("Invalid UserName", "Invalid Data");
            if (String.IsNullOrEmpty(register.MobileNumber))
                throw new BadRequestException("Invalid MobileNumber", "Invalid Data");
            if (String.IsNullOrEmpty(register.Password))
                throw new BadRequestException("Invalid Password", "Invalid Data");
            if (String.IsNullOrEmpty(register.ConfirmPassword))
                throw new BadRequestException("Invalid ConfirmPassword", "Invalid Data");

            var sec = worker.secretaryRepository.getByEmail(register.Email);
            if (sec != null)
                throw new InvalidDataException("Invalid Email already exists", "Invalid Data");
            if (register.Password != register.ConfirmPassword)
                throw new InvalidDataException("Password and ConfirmPassword not match", "Invalid Data");

            var clinic = worker.clinicRepository.Get(1);
            var regSecretary = new Secretary
            {
                MobileNumber = register.MobileNumber,
                Password = register.Password,
                Email = register.Email,
                UserName = register.UserName,
                CreatedAt = DateTime.Now,
                Clinic = clinic
            };

            worker.secretaryRepository.ResgisterSecretary(regSecretary);
            worker.Complete();
        }

        public SecretaryVM getSecretary(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Secretary Id", "Invalid Data");
            var doctor = worker.secretaryRepository.Get(id);
            if (doctor == null)
                throw new NotFoundException("Secretary doesn't exists", "Not Found");
            return ConvertVM(doctor);
        }
        public int Login(LoginViewModel login)
        {
            if (login == null)
                throw new BadRequestException("Invalid login data", "Invalid Data");
            if (String.IsNullOrEmpty(login.Email))
                throw new BadRequestException("Invalid Email", "Invalid Data");
            if (String.IsNullOrEmpty(login.Password))
                throw new BadRequestException("Invalid Password", "Invalid Data");

            var sec = worker.secretaryRepository.getByEmail(login.Email);
            if (sec == null)
                throw new InvalidDataException("Invalid Email not already exists", "Invalid Data");
            if (sec.Password != login.Password)
                throw new InvalidDataException("Wrong Password", "Invalid Data");
            sec.IsActive = true;
            worker.Complete();
            return sec.Id;

        }
    }
}
