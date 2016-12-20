namespace MedicationTrackFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MedicationTrackDataModel : DbContext
    {
        public MedicationTrackDataModel()
            : base("name=MedicationTrackDataModel")
        {
        }

       
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Medication>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .Property(e => e.Strength)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .Property(e => e.MedType)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .Property(e => e.Directions)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .Property(e => e.Quantity)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .Property(e => e.DaySupply)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Gender)
                .IsUnicode(false);

          
        }
    }
}
