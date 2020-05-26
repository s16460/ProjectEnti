using EntitytProject.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Services
{
    public interface IDoctorService
    {
        public IActionResult getDoctors();
        public IActionResult getDoctor(int id);
        public IActionResult addDoctor(DoctorReq doctor);
        public IActionResult updateDoctor(DoctorReq doctor);
        public IActionResult deleteDoctor(int id);
    }
}
