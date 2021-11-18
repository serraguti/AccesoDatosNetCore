using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class IncrementoEmpleadoController : Controller
    {
        EmpleadosContext context;

        public IncrementoEmpleadoController(EmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int idempleado, int incremento)
        {
            int afectados = this.context.IncrementarSalarioEmpleado(idempleado, incremento);
            Empleado empleado = this.context.BuscarEmpleado(idempleado);
            ViewBag.Mensaje = "Registros modificados: " + afectados;
            return View(empleado);
        }
    }
}
