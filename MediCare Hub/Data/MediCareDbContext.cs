using MediCare_Hub.Models;
using Microsoft.EntityFrameworkCore;

namespace MediCare_Hub.Data
{
    public class MediCareDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public MediCareDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MediCareDbContext()
        {
        }
    }
}
