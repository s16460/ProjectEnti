using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Services
{
    public class SeedServiceImpl : ControllerBase, ISeedService
    {

        private readonly MSDatabaseContext context;

        public SeedServiceImpl(MSDatabaseContext context)
        {
            this.context = context;
        }

        public IActionResult seedDataBase()
        {
            Doctor doc1 = new Doctor { 
                FirstName = "Tadek",
                LastName = "Niejadek",
                Email = "td@td.pl"
                };

            Doctor doc2 = new Doctor
            {
                FirstName = "Jeremi",
                LastName = "Niezgoda",
                Email = "jn@jn.pl"
            };

            Doctor doc3 = new Doctor
            {
                FirstName = "Gerwazy",
                LastName = "Klucznik",
                Email = "gk@gk.pl"
            };

            Doctor doc4 = new Doctor
            {
                FirstName = "Henryk",
                LastName = "Zarazek",
                Email = "hz@hz.pl"
            };

            Doctor doc5 = new Doctor
            {
                FirstName = "Wlodzimierz",
                LastName = "Wielki",
                Email = "ww@ww.pl"
            };
            context.Doctors.Add(doc1);
            context.Doctors.Add(doc2);
            context.Doctors.Add(doc3);
            context.Doctors.Add(doc4);
            context.Doctors.Add(doc5);


            var patients = new List<Patient>
            {
                new Patient { FirstName = "Eugenia", LastName = "Rozumna", Date = DateTime.Now },
                new Patient { FirstName = "Krystyna", LastName = "Biszkopt", Date = DateTime.Now },
                new Patient { FirstName = "Bozena", LastName = "Martwa", Date = DateTime.Now },
                new Patient { FirstName = "Genowefa", LastName = "Chora", Date = DateTime.Now },
                new Patient { FirstName = "Paylina", LastName = "Borowa", Date = DateTime.Now },
            };

            patients.ForEach(p => context.Patients.Add(p));


            var meds = new List<Medicament>
            {
                new Medicament { Name = "Panadol", Description = "Na bol" },
                new Medicament { Name = "Etopiryna", Description = "dla gozdzikowej" },
                new Medicament { Name = "marysia", Description = "na dola" },
                new Medicament { Name = "kwasik", Description = "na smoka" },
                new Medicament { Name = "acodin", Description = "na kaszel" },
                new Medicament { Name = "septolete", Description = "na gardlo" },
                new Medicament { Name = "penicylina", Description = "na wszystko" },
            };

            meds.ForEach(m => context.Medicaments.Add(m));
            context.SaveChanges();


            var doctorsIds = context.Doctors.Select(d => d.IdDoctor).ToList();
            var patienstIds = context.Patients.Select(p => p.IdPatient).ToList();

            var prescriptions = new List<Prescription>
            {
                new Prescription { IdDoctor = doctorsIds[0], IdPatient = patienstIds[0], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[1], IdPatient = patienstIds[1], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[2], IdPatient = patienstIds[2], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[3], IdPatient = patienstIds[3], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[4], IdPatient = patienstIds[4], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[1], IdPatient = patienstIds[2], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[1], IdPatient = patienstIds[3], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[3], IdPatient = patienstIds[1], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[2], IdPatient = patienstIds[0], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[4], IdPatient = patienstIds[0], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[3], IdPatient = patienstIds[4], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[0], IdPatient = patienstIds[4], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[0], IdPatient = patienstIds[2], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[2], IdPatient = patienstIds[3], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[4], IdPatient = patienstIds[2], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[4], IdPatient = patienstIds[4], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[2], IdPatient = patienstIds[3], Date = DateTime.Now, DueDate = DateTime.Now },
                new Prescription { IdDoctor = doctorsIds[1], IdPatient = patienstIds[2], Date = DateTime.Now, DueDate = DateTime.Now }
            };

            prescriptions.ForEach(p => context.Prescriptions.Add(p));
            context.SaveChanges();

            var prescriptionsIds = context.Prescriptions.Select(p => p.IdPrescription).ToList();
            var medsIds = context.Medicaments.Select(m => m.IdMedicament).ToList();

            var prescriptedMeds = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament { IdMedicament = medsIds[0], IdPrescription = prescriptionsIds[0], Details = "jedz", Dose = 1 },
                new PrescriptionMedicament { IdMedicament = medsIds[1], IdPrescription = prescriptionsIds[1], Details = "jedz", Dose = 2 },
                new PrescriptionMedicament { IdMedicament = medsIds[2], IdPrescription = prescriptionsIds[2], Details = "jedz", Dose = 3 },
                new PrescriptionMedicament { IdMedicament = medsIds[3], IdPrescription = prescriptionsIds[3], Details = "jedz", Dose = 4 },
                new PrescriptionMedicament { IdMedicament = medsIds[4], IdPrescription = prescriptionsIds[4], Details = "jedz", Dose = 5 },
                new PrescriptionMedicament { IdMedicament = medsIds[2], IdPrescription = prescriptionsIds[1], Details = "jedz", Dose = 1 },
                new PrescriptionMedicament { IdMedicament = medsIds[2], IdPrescription = prescriptionsIds[4], Details = "jedz", Dose = 6 },
                new PrescriptionMedicament { IdMedicament = medsIds[3], IdPrescription = prescriptionsIds[2], Details = "jedz", Dose = 7 },
                new PrescriptionMedicament { IdMedicament = medsIds[4], IdPrescription = prescriptionsIds[3], Details = "jedz", Dose = 9 },
                new PrescriptionMedicament { IdMedicament = medsIds[1], IdPrescription = prescriptionsIds[3], Details = "jedz", Dose = 8 },
                new PrescriptionMedicament { IdMedicament = medsIds[1], IdPrescription = prescriptionsIds[2], Details = "jedz", Dose = 7 },
                new PrescriptionMedicament { IdMedicament = medsIds[2], IdPrescription = prescriptionsIds[0], Details = "jedz", Dose = 6 },
                new PrescriptionMedicament { IdMedicament = medsIds[0], IdPrescription = prescriptionsIds[1], Details = "jedz", Dose = 2 },
                new PrescriptionMedicament { IdMedicament = medsIds[0], IdPrescription = prescriptionsIds[2], Details = "jedz", Dose = 4 },
                new PrescriptionMedicament { IdMedicament = medsIds[0], IdPrescription = prescriptionsIds[3], Details = "jedz", Dose = 6 },
                new PrescriptionMedicament { IdMedicament = medsIds[2], IdPrescription = prescriptionsIds[3], Details = "jedz", Dose = 9 },
                new PrescriptionMedicament { IdMedicament = medsIds[3], IdPrescription = prescriptionsIds[4], Details = "jedz", Dose = 2 },
                new PrescriptionMedicament { IdMedicament = medsIds[4], IdPrescription = prescriptionsIds[2], Details = "jedz", Dose = 3 }
            };

            prescriptedMeds.ForEach(pm => context.PrescriptionMedicaments.Add(pm));

            context.SaveChanges();

            return Ok("zaladowano dane");
        }
    }
}
