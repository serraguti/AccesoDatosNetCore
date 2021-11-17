using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class MaestroDetalleEmpleadosController : Controller
    {
        EmpleadosContext context;

        public MaestroDetalleEmpleadosController(EmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult DatosEmpleados()
        {
            List<Empleado> listaempleados = this.context.GetEmpleados();
            return View(listaempleados);
        }

        public IActionResult DetallesEmpleado(int idempleado)
        {
            Empleado empleado = this.context.BuscarEmpleado(idempleado);
            return View(empleado);
        }
    }
}
