using MediCare_Hub.Models;
using Microsoft.Identity.Client;

namespace MediCare_Hub.Services.Interfaces
{
    public interface IDoctorService
    {
        public List<Doctor> GetAllDoctors();
        public Doctor GetDoctorById(int id);
        public void AddDoctor(Doctor doctor);
        public void UpdateDoctor(Doctor doctor);
        public void RemoveDoctor(int id);
        public List<Doctor> GetDoctorsByHospitalId(int hospitalId);
        public List<Doctor> GetDoctorsBySalaryRange(float? minSalary = null, float? maxSalary = null);
    }
}
