using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class PlantillaTurnoController : Controller
    {
        PlantillaContext context;

        public PlantillaTurnoController(PlantillaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Plantilla> listaplantilla = this.context.GetPlantilla();
            return View(listaplantilla);
        }

        [HttpPost]
        public IActionResult Index(String turno)
        {
            List<Plantilla> listaplantilla = this.context.GetPlantillaTurno(turno);
            return View(listaplantilla);
        }
    }
}
