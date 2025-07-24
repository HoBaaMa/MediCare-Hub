using MediCare_Hub.Models;
using MediCare_Hub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MediCare_Hub.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        #region Actions
        public IActionResult Index()
        {
            return View(_doctorService.GetAllDoctors());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorService.AddDoctor(doctor);
                return RedirectToAction("Index");
            }
            else
            {
                return View(doctor);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_doctorService.GetDoctorById(id));
        }
        
        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            Doctor existingDoctor = _doctorService.GetDoctorById(doctor.Id);
            if (ModelState.IsValid)
            {
                _doctorService.UpdateDoctor(doctor);
                return RedirectToAction("Index");
            }
            else
            {
                return View(doctor);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _doctorService.RemoveDoctor(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
