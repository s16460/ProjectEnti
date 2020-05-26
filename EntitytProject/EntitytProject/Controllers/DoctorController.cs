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
            return doctorService.getDoctors();
        }

        [HttpGet]
        [Route("single")]
        public IActionResult GetDoctor(int id)
        {
            return doctorService.getDoctor(id);
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorReq newDoctor)
        {
            return doctorService.addDoctor(newDoctor);
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorReq doctorToUpdate)
        {
            return doctorService.updateDoctor(doctorToUpdate);
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            return doctorService.deleteDoctor(id);
        }



    }
}
