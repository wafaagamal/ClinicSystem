using Business.Contracts;
using Business.Logic.SecretaryBL;
using Business.Presentation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Clinic.Controllers
{
    public class SecretaryController : Controller
    {

        IUnitOfWork UOW;
        SecretaryLogic secretaryLogic;
        public SecretaryController(IUnitOfWork uow)
        {
            UOW = uow;
            secretaryLogic = new SecretaryLogic(UOW);
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult MakeAppointment(int docId, int patId, int schId)
        {
            secretaryLogic.MakeAppointment(docId, schId, patId);
            return View();
        }
        public ActionResult GetSecretary(int id)
        {
            var result = secretaryLogic.getSecretary(id);
            ViewData.Model = result;
            return View();
        }
        
    }
}
