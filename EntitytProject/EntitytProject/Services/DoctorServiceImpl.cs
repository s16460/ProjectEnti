using EntitytProject.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Services
{
    public class DoctorServiceImpl : ControllerBase, IDoctorService
    {

        private readonly MSDatabaseContext context;
        public DoctorServiceImpl(MSDatabaseContext context)
        {
            this.context = context;
        }

        public IActionResult getDoctors()
        {
            List<DoctorResp> doctors = context.Doctors.Select(d => new DoctorResp
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }).ToList();
            
            return Ok(doctors);
        }

        public IActionResult getDoctor(int id)
        {
            var maxId = context.Doctors.Max(d => d.IdDoctor);
            if(maxId < id)
            {
                return BadRequest("nie ma doktora o podanym id");
            }
            var doctor = context.Doctors.Where(d => d.IdDoctor == id).Select(d => new DoctorResp
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            });
           
            return Ok(doctor);
        }

        public IActionResult addDoctor(DoctorReq doctor)
        {
            Doctor doc = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            try
            {
                context.Doctors.Add(doc);
                context.SaveChanges();
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest("Nie moge doktora doktora");
            }
            return Ok("dodano doktora " + doctor);
        }

        public IActionResult updateDoctor(DoctorReq doctor)
        {

            Doctor doctorToUpdate = context.Doctors.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();

            if (doctorToUpdate == null)
            {
                return BadRequest("nie ma doktora o id " + doctor.IdDoctor);
            }

            doctorToUpdate.FirstName = doctor.FirstName;
            doctorToUpdate.LastName = doctor.LastName;
            doctorToUpdate.Email = doctor.Email;

            try
            {
                context.Doctors.Update(doctorToUpdate);
                context.SaveChanges();
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest("Nie moge updejtowac doktora o id " + doctor.IdDoctor);
            }
            return Ok(doctor);
        }

        public IActionResult deleteDoctor(int id)
        {
            Doctor doctorToDel = context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();


            if (doctorToDel == null)
            {
                return BadRequest("nie ma doktora o id "+ id);
            }
            try
            {
                context.Doctors.Remove(doctorToDel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest("Nie moge usunac doktora o id " + id);
            }
            return Ok("doktor usuniety");
        }
    }
}
