using AccesoDatosNetCore.Data;
using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class EnfermosController : Controller
    {
        EnfermosContext context;

        public EnfermosController(EnfermosContext context)
        {
            this.context = context;
        }

        //LOS PARAMETROS OPCIONALES LOS RECIBIREMOS COMO STRING
        //AUNQUE SEAN NUMEROS
        public IActionResult EliminarEnfermosGet(string inscripcion)
        {
            //DEBEMOS PREGUNTAR SI LA INSCRIPCION HA VENIDO O NO...
            if (inscripcion != null)
            {
                //PODEMOS ELIMINAR
                int eliminados = this.context.EliminarEnfermo(int.Parse(inscripcion));
                ViewBag.Mensaje = "Eliminados: " + eliminados;
            }
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }

        public IActionResult EliminarEnfermosFormulario()
        {
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }

        [HttpPost]
        public IActionResult EliminarEnfermosFormulario(int inscripcion)
        {
            int eliminados = this.context.EliminarEnfermo(inscripcion);
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }
    }
}
