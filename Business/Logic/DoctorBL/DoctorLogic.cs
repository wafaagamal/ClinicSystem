using Business.Contracts;
using Business.Presentation;
using Common.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Logic.Clinic.DoctorBL
{

    public class DoctorLogic
    {
        IUnitOfWork worker;
        public DoctorLogic(IUnitOfWork work)
        {
            worker = work;
        }
        private DoctorVM ConvertVM(Doctor doctor)
        {
            return new DoctorVM
            {
                UserName = doctor.UserName,
                IsActive = doctor.IsActive,
                MobileNumber = doctor.MobileNumber,
                Email=doctor.Email,
                Id = doctor.Id
            };
        }
        private List<DoctorVM> ConvertVMs(List<Doctor> doctors)
        {
            List<DoctorVM> doctorVMs = new List<DoctorVM>();
            foreach (var doc in doctors)
            {
                doctorVMs.Add(ConvertVM(doc));
            }
            return doctorVMs;
        }

        private AppointmentResultVM AppointmentVM(Appointment appointment)
        {
            return new AppointmentResultVM
            {
                Patient = new PatientVM
                {
                    UserName = appointment.Patient.UserName,
                    age = appointment.Patient.age,
                    Address = appointment.Patient.Address,
                    BirthDate = appointment.Patient.BirthDate,
                    Id = appointment.Patient.Id,
                    MobileNumber = appointment.Patient.MobileNumber
                },
                Schedule = new ScheduleVM
                {
                    Day = appointment.Schedule.Day,
                    From = appointment.Schedule.From,
                    To = appointment.Schedule.To,
                    Id = appointment.Schedule.Id
                }
            };
        }
        private List<AppointmentResultVM> AppointmentResultVMs(List<Appointment> appointments)
        {
            List<AppointmentResultVM> appointmentVMs = new List<AppointmentResultVM>();
            foreach (var app in appointments)
            {
                appointmentVMs.Add(AppointmentVM(app));
            }
            return appointmentVMs;
        }

        public DoctorVM getDoctor(int doctorId)
        {
            if (doctorId <= 0)
                throw new BadRequestException("Invalid doctor Id", "Invalid Data");
            var doctor = worker.doctorRespository.Get(doctorId);
            if (doctor == null)
                throw new NotFoundException("Doctor doesn't exists", "Not Found");
            return ConvertVM(doctor);
        }
        public List<DoctorVM> getDoctors()
        {
            var doctors = worker.doctorRespository.GetALL().ToList();
            return ConvertVMs(doctors);
        }
        public List<AppointmentResultVM> GetAppointments(int docId)
        {
            if (docId <= 0)
                throw new BadRequestException("Invalid doctor Id", "Invalid Data");
            var appointments = worker.appointmentRepository.getByDoctor(docId);
            return AppointmentResultVMs(appointments);
        }
        public List<AppointmentResultVM> GetAppointmentsByRange(int docId, decimal from, decimal to, DayOfWeek day)
        {
            if (docId <= 0)
                throw new BadRequestException("Invalid doctor Id", "Invalid Data");

            if (from <= 0 || to <= 0 || !Enum.IsDefined(typeof(DayOfWeek), day))
                throw new BadRequestException("Invalid time", "Invalid Data");

            var appointments = worker.appointmentRepository.getByDoctorwithRange(docId, from, to, day);
            return AppointmentResultVMs(appointments);
        }
        public void Register(RegisterViewModel doctorVM)
        {
            if(doctorVM==null)
                throw new BadRequestException("Invalid doctor data", "Invalid Data");
            if(String.IsNullOrEmpty(doctorVM.Email))
                throw new BadRequestException("Invalid Email", "Invalid Data");
            if (String.IsNullOrEmpty(doctorVM.UserName))
                throw new BadRequestException("Invalid UserName", "Invalid Data");
            if (String.IsNullOrEmpty(doctorVM.MobileNumber))
                throw new BadRequestException("Invalid MobileNumber", "Invalid Data");
            if (String.IsNullOrEmpty(doctorVM.Password))
                throw new BadRequestException("Invalid Password", "Invalid Data");
            if (String.IsNullOrEmpty(doctorVM.ConfirmPassword))
                throw new BadRequestException("Invalid ConfirmPassword", "Invalid Data");

            var doc = worker.doctorRespository.getByEmail(doctorVM.Email);
            if(doc!=null)
                throw new InvalidDataException("Invalid Email already exists", "Invalid Data");
            if(doctorVM.Password!=doctorVM.ConfirmPassword)
                throw new InvalidDataException("Password and ConfirmPassword not match", "Invalid Data");

            var clinic = worker.clinicRepository.Get(1);
            var regDoctor = new Doctor
            {
                MobileNumber = doctorVM.MobileNumber,
                Password = doctorVM.Password,
                Email = doctorVM.Email,
                UserName = doctorVM.UserName,
                CreatedAt = DateTime.Now,
                Clinic = clinic
            };

            worker.doctorRespository.ResgisterDoctor(regDoctor);
            worker.Complete();
        }
        public int Login(LoginViewModel login)
        {
            if(login==null)
                throw new BadRequestException("Invalid login data", "Invalid Data");
            if (String.IsNullOrEmpty(login.Email))
                throw new BadRequestException("Invalid Email", "Invalid Data");
            if (String.IsNullOrEmpty(login.Password))
                throw new BadRequestException("Invalid Password", "Invalid Data");

            var doc = worker.doctorRespository.getByEmail(login.Email);
            if (doc == null)
                throw new InvalidDataException("Invalid Email not already exists", "Invalid Data");
            if(doc.Password!=login.Password)
                throw new InvalidDataException("Wrong Password", "Invalid Data");
            doc.IsActive = true;
            worker.Complete();
            return doc.Id;

        }
    }
}
