using Business.Contracts;
using Business.Logic.SecretaryBL;
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
    public class SecretaryController : ControllerBase
    {
        IUnitOfWork UOW;
        SecretaryLogic  secretaryLogic;
        public SecretaryController(IUnitOfWork uow)
        {
            UOW = uow;
            secretaryLogic = new SecretaryLogic(UOW);
        }
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200)]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpPost("appointment/{docId}/{patId}/{schId}")]
        public IActionResult MakeAppointment(int docId,int patId, int schId)
        {
            try
            {
                secretaryLogic.MakeAppointment(docId, schId,patId);
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
            catch (NotFoundException ex)
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

        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200)]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel doctorVM)
        {

            try
            {
                secretaryLogic.Register(doctorVM);
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


        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200)]
        [ProducesResponseType(StatusCodes.Status204NoContent, StatusCode = 204)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound, StatusCode = 404, Type = typeof(ErrorResponseVM))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, StatusCode = 500, Type = typeof(ErrorResponseVM))]
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel doctorVM)
        {

            try
            {
                secretaryLogic.Login(doctorVM);
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
