using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class EmpleadosOficiosController : Controller
    {
        EmpleadosContext context;

        public EmpleadosOficiosController(EmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<string> listaoficios = this.context.GetOficios();
            ViewBag.Oficios = listaoficios;
            return View();
        }

        [HttpPost]
        public IActionResult Index(String oficio)
        {
            List<Empleado> listaempleados = this.context.GetEmpleadosOficio(oficio);
            List<string> listaoficios = this.context.GetOficios();
            ViewBag.Oficios = listaoficios;
            return View(listaempleados);
        }
    }
}
