using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;

namespace AccesoDatosNetCore.Data
{
    public class EnfermosContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public EnfermosContext(string cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Enfermo> GetEnfermos()
        {
            String sql = "select * from enfermo";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Enfermo> listaenfermos = new List<Enfermo>();
            while (this.reader.Read())
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Inscripcion = int.Parse(this.reader["INSCRIPCION"].ToString());
                enfermo.Apellido = this.reader["APELLIDO"].ToString();
                enfermo.Direccion = this.reader["DIRECCION"].ToString();
                enfermo.FechaNacimiento = this.reader["FECHA_NAC"].ToString();
                listaenfermos.Add(enfermo);
            }

            this.reader.Close();
            this.cn.Close();
            return listaenfermos;
        }

        public int EliminarEnfermo(int inscripcion)
        {
            String sql = "delete from enfermo where inscripcion=@inscripcion";
            this.com.CommandText = sql;
            SqlParameter paminscripcion = new SqlParameter("@inscripcion", inscripcion);
            this.com.Parameters.Add(paminscripcion);
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return eliminados;
        }
    }
}
