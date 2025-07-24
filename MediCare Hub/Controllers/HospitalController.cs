using MediCare_Hub.Models;
using MediCare_Hub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediCare_Hub.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        #region Actions
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_hospitalService.GetAllHospitals());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _hospitalService.AddHospital(hospital);
                return RedirectToAction("Index");
            }
            else
            {
                return View(hospital);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_hospitalService.GetHospitalById(id));
        }
        [HttpPost]
        public IActionResult Update (Hospital hospital)
        {
            _hospitalService.UpdateHospital(hospital);
            return RedirectToAction("Index");
        }
        [HttpGet] 
        public IActionResult Delete(int id)
        {
            _hospitalService.DeleteHospital(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
