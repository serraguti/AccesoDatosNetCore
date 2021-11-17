using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;
using AccesoDatosNetCore.Data;

namespace AccesoDatosNetCore.Controllers
{
    public class PlantillasController : Controller
    {
        PlantillaContext context;

        public PlantillasController(PlantillaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Plantilla> listaplantilla = this.context.GetPlantilla();
            return View(listaplantilla);
        }
    }
}
