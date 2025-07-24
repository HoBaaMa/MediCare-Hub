using MediCare_Hub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare_Hub.Controllers
{
    public class DoctorsWithHospitals : Controller
    {
        private readonly MediCareDbContext _context;
        public DoctorsWithHospitals(MediCareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Hospitals
                .Include(h => h.Doctors)
                .SelectMany(d => d.Doctors, (h, d) => new
                {
                    HospitalName = h.Name,
                    DoctorName = d.Name,
                    Qualification = d.Qualification
                })
                .ToList();
            return View(data);
        }
    }
}
