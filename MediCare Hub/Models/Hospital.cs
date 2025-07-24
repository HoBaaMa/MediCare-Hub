using System.ComponentModel.DataAnnotations;

namespace MediCare_Hub.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
