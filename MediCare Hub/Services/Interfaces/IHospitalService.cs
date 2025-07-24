using MediCare_Hub.Models;

namespace MediCare_Hub.Services.Interfaces
{
    public interface IHospitalService
    {
        public List<Hospital> GetAllHospitals();
        public Hospital GetHospitalById(int id);
        public void AddHospital(Hospital hospital);
        public void UpdateHospital(Hospital hospital);
        public void DeleteHospital(int id);

    }
}
