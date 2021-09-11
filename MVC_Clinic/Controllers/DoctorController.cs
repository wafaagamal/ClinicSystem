using Business.Contracts;
using Business.Logic.Clinic.DoctorBL;
using Business.Presentation;
using Microsoft.AspNetCore.Mvc;
using MVC_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace MVC_Clinic.Controllers
{
    public class DoctorController : Controller
    {
        IUnitOfWork UOW;
        DoctorLogic doctorLogic;
        public DoctorController(IUnitOfWork uow)
        {
            UOW = uow;
            doctorLogic = new DoctorLogic(UOW);

        }


        public ActionResult GetDoctor(int id)
        {
            var result = doctorLogic.getDoctor(id);
            ViewData.Model = result;
            return View();
        }

        public ActionResult GetDoctors()
        {
            List<DoctorVM> result = doctorLogic.getDoctors();
            return View(result);
        }

        public ActionResult MyAppointments(int id)
        {
            List<AppointmentResultVM> result = doctorLogic.GetAppointments(id);
            ViewBag.IsRenderd = false;
            return View(result);
        }

        public JsonResult AppointmentsByRange(int id, decimal from, decimal to, string myDays)
        {
           
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), myDays, true);
            List<AppointmentResultVM> result = doctorLogic.GetAppointmentsByRange(id, from, to, dayOfWeek);
            ViewBag.IsRenderd = true;
            return Json(result);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
