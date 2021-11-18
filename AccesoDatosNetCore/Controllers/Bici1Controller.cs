using AccesoDatosNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Controllers
{
    public class Bici1Controller : Controller
    {
        private Bicicleta bici;
        public Bici1Controller(Bicicleta bici)
        {
            this.bici = bici;
        }

        //GET
        public IActionResult Index()
        {
            return View(this.bici);
        }

        public IActionResult Index2()
        {
            return View(this.bici);
        }

        //HTTPPOST
        [HttpPost]
        public IActionResult Index(String accion)
        {
            if (accion == "acelerar")
            {
                this.bici.Acelerar();
            }else
            {
                this.bici.Frenar();
            }
            return View(this.bici);
        }
    }
}
