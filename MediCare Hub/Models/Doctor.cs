using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediCare_Hub.Models
{
    public class Doctor
    {
        [DisplayName("Doctor ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [DefaultValue(0.0)]
        public float Salary { get; set; }
        [Required]
        public string Qualification { get; set; }
        // Foreign Key
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }

        // Navigation Property
        public Hospital? Hospital { get; set; }
    }
}
