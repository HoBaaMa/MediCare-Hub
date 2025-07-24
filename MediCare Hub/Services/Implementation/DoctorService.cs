using MediCare_Hub.Data;
using MediCare_Hub.Models;
using MediCare_Hub.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MediCare_Hub.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly MediCareDbContext _context;

        public DoctorService(MediCareDbContext context)
        {
            _context = context;
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void RemoveDoctor(int id)
        {
            Doctor doctor = GetDoctorById(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            Doctor existingDoctor = GetDoctorById(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.Name = doctor.Name;
                existingDoctor.Salary = doctor.Salary;
                existingDoctor.Qualification = doctor.Qualification;
                existingDoctor.HospitalId = doctor.HospitalId;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Doctor with ID {doctor.Id} not found.");
            }
        }

        public List<Doctor> GetAllDoctors() => _context.Doctors.ToList();
        public Doctor GetDoctorById(int id) => _context.Doctors.Where(d => d.Id == id).FirstOrDefault();
        public List<Doctor> GetDoctorsByHospitalId(int hospitalId) => _context.Doctors.Where(d => d.HospitalId == hospitalId).ToList();
        public List<Doctor> GetDoctorsBySalaryRange(float? minSalary = null, float? maxSalary =null)
        {
            var query = _context.Doctors.AsQueryable();
            if (minSalary.HasValue)
            {
                query = query.Where(s => s.Salary >= minSalary.Value);
            }
            if (maxSalary.HasValue)
            {
                query = query.Where(s => s.Salary <= maxSalary.Value);
            }
            return query.ToList();

            // If you want to use a stored procedure, you can uncomment the following code
            //var minParam = new SqlParameter("@MinSalary", minSalary ?? (object)DBNull.Value);
            //var maxParam = new SqlParameter("@MaxSalary", maxSalary ?? (object)DBNull.Value);

            //return _context.Doctors
            //    .FromSqlRaw("EXEC GetDoctorsBySalaryRange @MinSalary, @MaxSalary", minParam, maxParam)
            //    .ToList();
        }
    }
}
