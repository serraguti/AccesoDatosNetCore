using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class IncrementoPlantillaFuncionesController : Controller
    {
        PlantillaContext context;

        public IncrementoPlantillaFuncionesController(PlantillaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<string> listafunciones = this.context.GetFunciones();
            ViewBag.Funciones = listafunciones;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string funcion, int incremento)
        {
            List<string> listafunciones = this.context.GetFunciones();
            ViewBag.Funciones = listafunciones;
            //PRIMERO DEBEMOS MODIFICAR
            int modificados = this.context.UpdatePlantillaFuncion(funcion, incremento);
            //UNA VEZ MODIFICADOS LOS DATOS, LOS RECUPERAMOS
            List<Plantilla> listaplantilla = this.context.GetPlantillaFunciones(funcion);
            ViewBag.Mensaje = "Empleados modificados: " + modificados;
            return View(listaplantilla);
        }
    }
}
