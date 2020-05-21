using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Cw11.Models
{
    public class MyDbContext :DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> prescriptionMedicament { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBulider) 
        {
            modelBulider.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });
            modelBulider.Entity<Doctor>(entity =>
            {
                entity.HasKey(k => k.IdDoctor).HasName("Doctor_PK");
                entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Email).HasMaxLength(100).IsRequired();
            });

            modelBulider.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()").IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(d => d.IdPatient)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("Prescription_Patient_FK");

                entity.HasOne(d => d.Doctor)
                    .WithMany(d => d.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Doctor_Prescription_FK");
            });

            modelBulider.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => new { e.IdPrescription, e.IdMedicament }).HasName("Prescription_Medicament_PK");
            });


        }

    }
}
