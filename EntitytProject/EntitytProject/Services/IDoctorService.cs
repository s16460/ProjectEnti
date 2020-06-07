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
        public List<DoctorResp> getDoctors();
        public IQueryable<DoctorResp> getDoctor(int id);
        public String addDoctor(DoctorReq doctor);
        public String updateDoctor(DoctorReq doctor);
        public String deleteDoctor(int id);
    }
}
