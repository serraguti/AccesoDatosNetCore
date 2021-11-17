using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;

namespace AccesoDatosNetCore.Controllers
{
    public class EmpleadosController : Controller
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public EmpleadosController()
        {
            this.cadenaconexion = @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            this.cn = new SqlConnection(this.cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public IActionResult Index()
        {
            string sql = "select * from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            //VAMOS A LEER UN CONJUNTO DE EMPLEADOS
            //POR LO QUE NECESITAMOS UNA COLECCION DE EMPLEADOS
            List<Empleado> listaempleados = new List<Empleado>();
            //COMENZAMOS A LEER REGISTROS
            while (this.reader.Read())
            {
                //TENEMOS QUE CREAR UN EMPLEADO POR CADA FILA
                Empleado empleado = new Empleado();
                //ASIGNAMOS LOS VALORES DEL READER A CADA EMPLEADO
                //EN SU PROPIEDAD
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
                //AÑADIMOS CADA EMPLEADO A LA LISTA
                listaempleados.Add(empleado);
            }

            this.reader.Close();
            this.cn.Close();
            //DEVOLVEMOS LOS EMPLEADOS A LA VISTA PARA DIBUJARLOS
            return View(listaempleados);
        }
    }
}
