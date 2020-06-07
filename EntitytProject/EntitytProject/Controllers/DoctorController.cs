using EntitytProject.DTO;
using EntitytProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {

            return Ok(doctorService.getDoctors());
        }

        [HttpGet]
        [Route("single")]
        public IActionResult GetDoctor(int id)
        {
            if(doctorService.getDoctor(id) == null)
            {
                return BadRequest("brak doktora");
            }

            return Ok(doctorService.getDoctor(id));
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorReq newDoctor)
        {
            if (doctorService.addDoctor(newDoctor) == null)
            {
                return BadRequest("problem z dodaniem doktora");
            }
            return Ok(doctorService.addDoctor(newDoctor));
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorReq doctorToUpdate)
        {
            if (doctorService.updateDoctor(doctorToUpdate) == null)
            {
                return BadRequest("problem z updejtem doktora");
            }

            return Ok(doctorService.updateDoctor(doctorToUpdate));
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            if (doctorService.deleteDoctor(id) == null)
            {
                return BadRequest("problem z usnieciem doktora");
            }

            return Ok(doctorService.deleteDoctor(id));
        }



    }
}
