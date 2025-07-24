using MediCare_Hub.Data;
using MediCare_Hub.Models;
using MediCare_Hub.Services.Interfaces;


namespace MediCare_Hub.Services.Implementation
{
    public class HospitalService : IHospitalService
    {
        private readonly MediCareDbContext _context;
        #region Constructor
        public HospitalService(MediCareDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public void AddHospital(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            _context.SaveChanges();
        }

        public void DeleteHospital(int id)
        {
            Hospital hospital = GetHospitalById(id);
            if (hospital != null)
            {
                _context.Hospitals.Remove(hospital);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Hospital with ID {id} not found.");
            }
        }

        public void UpdateHospital(Hospital hospital)
        {
            Hospital existingHospital = GetHospitalById(hospital.Id);
            if (existingHospital != null)
            {
                existingHospital.Name = hospital.Name;
                existingHospital.Address = hospital.Address;
                existingHospital.City = hospital.City;
                _context.Hospitals.Update(existingHospital);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Hospital with ID {hospital.Id} not found.");
            }
        }
        public List<Hospital> GetAllHospitals() => _context.Hospitals.ToList();
        public Hospital GetHospitalById(int id) => _context.Hospitals.Where(h => h.Id == id).FirstOrDefault();
        #endregion

    }
}
