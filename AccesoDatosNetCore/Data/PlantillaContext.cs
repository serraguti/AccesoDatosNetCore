using AccesoDatosNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatosNetCore.Data
{
    public class PlantillaContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillaContext(string cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Plantilla> GetPlantilla()
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
                plantilla.Turno = this.reader["T"].ToString();
                plantilla.Salario = (int)this.reader["SALARIO"];
                listaplantilla.Add(plantilla);
            }

            this.reader.Close();
            this.cn.Close();
            return listaplantilla;
        }

        public List<Plantilla> GetPlantillaTurno(String turno)
        {
            String sql = "select * from plantilla where t=@turno";
            this.com.CommandText = sql;
            SqlParameter pamturno = new SqlParameter("@turno", turno);
            this.com.Parameters.Add(pamturno);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla plan = new Plantilla();
                plan.IdPlantilla = (int)this.reader["EMPLEADO_NO"];
                plan.Apellido = this.reader["APELLIDO"].ToString();
                plan.Funcion = this.reader["FUNCION"].ToString();
                plan.Turno = this.reader["T"].ToString();
                plan.Salario = (int)this.reader["SALARIO"];
                listaplantilla.Add(plan);
            }

            //SALIR
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            if (listaplantilla.Count == 0)
            {
                return null;
            }
            else
            {
                return listaplantilla;
            }
        }
    }
}
