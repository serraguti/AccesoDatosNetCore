using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class HospitalesController : Controller
    {
        HospitalContext context;

        public HospitalesController(HospitalContext context)
        {
            this.context = context;
        }

        public IActionResult Menu()
        {
            List<Hospital> hospitales = this.context.GetHospitales();
            return View(hospitales);
        }

        public IActionResult DetallesHospital(int idhospital)
        {
            Hospital hospital = this.context.FindHospital(idhospital);
            return View(hospital);
        }

        public IActionResult DoctoresHospital(int idhospital)
        {
            List<Doctor> doctores = this.context.GetDoctoresHospital(idhospital);
            return View(doctores);
        }

        public IActionResult PlantillaHospital(int idhospital)
        {
            List<Plantilla> plantillas = this.context.GetPlantillaHospital(idhospital);
            return View(plantillas);
        }
    }
}
