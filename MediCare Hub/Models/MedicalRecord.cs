using System.ComponentModel.DataAnnotations.Schema;

namespace MediCare_Hub.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime DateOfExamination { get; set; } = DateTime.Now; // تاريخ الكشف
        public string Problem { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        // Navigation property
        public Patient Patient { get; set; }  // السجل الطبي يتبع مريض واحد
    }
}
