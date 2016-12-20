namespace MedicationTrackFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medication")]
    public partial class Medication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medication()
        {
            Patients = new HashSet<Patient>();
        }

        public int MedicationId { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fill Date")]
        public DateTime FillDate { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Medication Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Strength { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Med Type")]
        public string MedType { get; set; }

        [Required]
        [StringLength(120)]
        public string Directions { get; set; }

        [Required]
        [StringLength(20)]
        public string Quantity { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Day Supply")]
        public string DaySupply { get; set; }

     

        

       

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
