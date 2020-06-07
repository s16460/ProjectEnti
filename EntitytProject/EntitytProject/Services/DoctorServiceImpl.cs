using EntitytProject.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Services
{
    public class DoctorServiceImpl :  IDoctorService
    {

        private readonly MSDatabaseContext context;
        public DoctorServiceImpl(MSDatabaseContext context)
        {
            this.context = context;
        }

        public List<DoctorResp> getDoctors()
        {
            List<DoctorResp> doctors = context.Doctors.Select(d => new DoctorResp
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }).ToList();

            return doctors;
        }

        public IQueryable<DoctorResp> getDoctor(int id)
        {
            var maxId = context.Doctors.Max(d => d.IdDoctor);
            if(maxId < id)
            {
                return null;
            }
             var doctor = context.Doctors.Where(d => d.IdDoctor == id).Select(d => new DoctorResp
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            });

            return doctor;
        }

        public String addDoctor(DoctorReq doctor)
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
                return null;
            }
            return "dodano doktora";
        }

        public String updateDoctor(DoctorReq doctor)
        {

            Doctor doctorToUpdate = context.Doctors.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();

            if (doctorToUpdate == null)
            {
                return null;
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
                return null;
            }
            return "dodano doktora";
        }

        public String deleteDoctor(int id)
        {
            Doctor doctorToDel = context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();


            if (doctorToDel == null)
            {
                return null;
            }
            try
            {
                context.Doctors.Remove(doctorToDel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
            return "usunieto";
        }
    }
}
