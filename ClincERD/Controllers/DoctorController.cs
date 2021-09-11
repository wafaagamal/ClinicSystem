using Business.Contracts;
using Business.Logic.Clinic.DoctorBL;
using Business.Presentation;
using Common.Exceptions;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrb_ClinicERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IUnitOfWork UOW;
        DoctorLogic doctorLogic;
        public DoctorController(IUnitOfWork uow)
        {
            UOW = uow;
            doctorLogic = new DoctorLogic(UOW);
        }

        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200,Type = typeof(DoctorVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            try
            {
                var result=doctorLogic.getDoctor(id);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200,Type = typeof(DoctorVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpGet("")]
        public IActionResult GetDoctors()
        {

            try
            {
                var result=doctorLogic.getDoctors();
                if (result.Count <= 0)
                    return NoContent();
                return Ok(result);

            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(AppointmentResultVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpGet("appointment/{id}")]
        public IActionResult MyAppointments(int id)
        {
            try
            {
                var result = doctorLogic.GetAppointments(id);
                if (result.Count <= 0)
                    return NoContent();
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(AppointmentResultVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpGet("appointment/{id}/{from}/{to}/{day}")]
        public IActionResult MyAppointmentsByRange(int id , decimal from, decimal to, DayOfWeek day)
        {

            try
            {
                var result = doctorLogic.GetAppointmentsByRange(id,from,to,day);
                if (result.Count <= 0)
                    return NoContent();
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(DoctorVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel doctorVM)
        {

            try
            {
                 doctorLogic.Register(doctorVM);
                 return Ok();

            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(DoctorVM))]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel doctorVM)
        {

            try
            {
                doctorLogic.Login(doctorVM);
                return Ok();

            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Subject = ex.Subject,
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseVM()
                {
                    Subject = "Server-Error",
                    Message = ex.Message
                });
            }

        }


    }
}
