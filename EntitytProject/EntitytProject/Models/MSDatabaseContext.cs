using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Services
{
    public class MSDatabaseContext : DbContext
    {
		
		// await context.doctor.defaultAsync -> zawsze przed async 
		//Z poziomu Package Manager Console zainstalować następującą paczkę: Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson
		//W klasie Startup w metodzie ConfigureServices zmienić linijkę w której jest wywołanie metody rozszerzeń AddControllers() na następującą treść:
		//services.AddControllers().AddNewtonsoftJson(options =>
	                //{
	                 //   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
	               // });
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; } 

        public MSDatabaseContext() { }

        public MSDatabaseContext(DbContextOptions<MSDatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.ToTable("Doctor");

                entity.HasMany(e => e.Prescriptions)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey(p => p.IdDoctor)
                    .IsRequired();

            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.Type).HasMaxLength(100);

                entity.ToTable("Medicament");

                entity.HasMany(e => e.PrescriptionMedicaments)
                    .WithOne(p => p.Medicament)
                    .HasForeignKey(p => p.IdMedicament)
                    .IsRequired();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.IdPatient).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.ToTable("Patient");

                entity.HasMany(e => e.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(p => p.IdPatient)
                    .IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

                entity.ToTable("Prescription");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                entity.Property(e => e.Details).HasMaxLength(100);
                entity.ToTable("Prescription_Medicament");
            });
        }
    }
}
