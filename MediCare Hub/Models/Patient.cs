using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediCare_Hub.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Digonosis { get; set; }
        public string? Address { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        // Navigation properties
        public Hospital Hospital { get; set; }  // لكل مريض مستشفى واحد
        public ICollection<MedicalRecord> MedicalRecords { get; set; } // المريض له أكتر من سجل

    }
}
