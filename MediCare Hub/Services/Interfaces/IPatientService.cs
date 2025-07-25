using MediCare_Hub.Models;

namespace MediCare_Hub.Services.Interfaces
{
    public interface IPatientService
    {
        public List<Patient> GetAllPatients();
        public Patient GetPatientById(int id);
        public void AddPatient(Patient patient);
        public void UpdatePatient(Patient patient);
        public void RemovePatient(int id);


    }
}
