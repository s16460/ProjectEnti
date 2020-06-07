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
            var resp = doctorService.getDoctor(id);
            if (resp == null)
            {
                return BadRequest("brak doktora");
            }

            return Ok(resp);
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorReq newDoctor)
        {
            var resp = doctorService.addDoctor(newDoctor);
            if (resp == null)
            {
                return BadRequest("problem z dodaniem doktora");
            }
            return Ok(resp);
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorReq doctorToUpdate)
        {
            var resp = doctorService.updateDoctor(doctorToUpdate);

            if (resp == null)
            {
                return BadRequest("problem z updejtem doktora");
            }

            return Ok(resp);
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            var resp = doctorService.deleteDoctor(id);
            if (resp == null)
            {
                return BadRequest("problem z usnieciem doktora");
            }

            return Ok(resp);
        }



    }
}
