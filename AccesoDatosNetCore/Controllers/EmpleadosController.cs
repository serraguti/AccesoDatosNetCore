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
    public class EmpleadosController : Controller
    {
        //DECLARAMOS NUESTRO OBJETO CONTEXT
        EmpleadosContext context;

        public EmpleadosController(EmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //UTILIZAMOS LOS METODOS QUE NECESITEMOS
            List<Empleado> listaempleados = this.context.GetEmpleados();
            return View(listaempleados);
        }
    }
}
