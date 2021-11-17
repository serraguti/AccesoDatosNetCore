using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;

namespace AccesoDatosNetCore.Controllers
{
    public class PlantillasController : Controller
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillasController()
        {
            this.cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            this.cn = new SqlConnection(this.cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public IActionResult Index()
        {
            String sql = "select * from plantilla";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla plantilla = new Plantilla();
                plantilla.IdPlantilla = (int)this.reader["EMPLEADO_NO"];
                plantilla.Apellido = this.reader["APELLIDO"].ToString();
                plantilla.Funcion = this.reader["FUNCION"].ToString();
                plantilla.Salario = (int)this.reader["SALARIO"];
                listaplantilla.Add(plantilla);
            }

            this.reader.Close();
            this.cn.Close();
            return View(listaplantilla);
        }
    }
}
