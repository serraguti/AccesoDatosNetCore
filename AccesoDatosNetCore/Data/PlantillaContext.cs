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
                plantilla.Salario = (int)this.reader["SALARIO"];
                listaplantilla.Add(plantilla);
            }

            this.reader.Close();
            this.cn.Close();
            return listaplantilla;
        }
    }
}
