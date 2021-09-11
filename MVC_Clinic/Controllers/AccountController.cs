using Business.Contracts;
using Business.Logic.Clinic.DoctorBL;
using Business.Logic.SecretaryBL;
using Business.Presentation;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Clinic.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork UOW;
        DoctorLogic doctorLogic;
        SecretaryLogic secretaryLogic;
        public AccountController(IUnitOfWork uow)
        {
            UOW = uow;
            doctorLogic = new DoctorLogic(UOW);
            secretaryLogic = new SecretaryLogic(UOW);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Role == true)
            {
                var res = doctorLogic.Login(model);
                return RedirectToAction("GetDoctor", "Doctor", new { id = res });

            }
            else
            {
                var res = secretaryLogic.Login(model);
                return RedirectToAction("GetSecretary", "Secretary", new { id = res });

            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Role == true)
                {
                    doctorLogic.Register(model);
                }
                else
                {
                    secretaryLogic.Register(model);
                }
            }
            return RedirectToAction("Login","Account");
        }
    }
}
