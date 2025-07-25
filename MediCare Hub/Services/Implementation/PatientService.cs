using MediCare_Hub.Data;
using MediCare_Hub.Models;
using MediCare_Hub.Services.Interfaces;

namespace MediCare_Hub.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly MediCareDbContext _context;
        public PatientService(MediCareDbContext context)
        {
            _context = context;
        }
        #region Methods
        public void AddPatient(Patient patient)
        { 
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void RemovePatient(int id)
        {
            Patient patient = GetPatientById(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }
        }

        public void UpdatePatient(Patient patient)
        {
            Patient existingPatient = GetPatientById(patient.Id);
            if (existingPatient != null)
            {
                existingPatient.Name = patient.Name;
                existingPatient.Digonosis = patient.Digonosis;
                existingPatient.Address = patient.Address;
                existingPatient.HospitalId = patient.HospitalId;
            }
            else
            {
                throw new KeyNotFoundException($"Patient with ID {patient.Id} not found.");
            }
        }
        public List<Patient> GetAllPatients() => _context.Patients.ToList();
        public Patient GetPatientById(int id) => _context.Patients.FirstOrDefault(p => p.Id == id);


        #endregion
    }
}
