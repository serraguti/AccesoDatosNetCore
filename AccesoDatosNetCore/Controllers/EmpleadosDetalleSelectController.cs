using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class EmpleadosDetalleSelectController : Controller
    {
        EmpleadosContext context;

        public EmpleadosDetalleSelectController(EmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Empleado> listaempleados = this.context.GetEmpleados();
            ViewBag.Empleados = listaempleados;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int idempleado)
        {
            Empleado empleado = this.context.BuscarEmpleado(idempleado);
            List<Empleado> listaempleados = this.context.GetEmpleados();
            ViewBag.Empleados = listaempleados;
            return View(empleado);
        }
    }
}
