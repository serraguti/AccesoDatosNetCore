using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;

namespace AccesoDatosNetCore.Data
{
    public class HospitalContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public HospitalContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Hospital> GetHospitales()
        {
            String sql = "select * from hospital";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospitales.Add(hospital);
            }

            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public Hospital FindHospital(int idhospital)
        {
            String sql = "select * from hospital where hospital_cod=@idhospital";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@idhospital", idhospital);
            this.com.Parameters.Add(pamid);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            Hospital hospital;
            if (this.reader.Read())
            {
                hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
            }
            else
            {
                hospital = null;
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return hospital;
        }

        public List<Plantilla> GetPlantillaHospital(int idhospital)
        {
            String sql = "select * from plantilla where hospital_cod=@idhospital";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@idhospital", idhospital);
            this.com.Parameters.Add(pamid);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla p = new Plantilla();
                p.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                p.Apellido = this.reader["APELLIDO"].ToString();
                p.Turno = this.reader["T"].ToString();
                p.Funcion = this.reader["FUNCION"].ToString();
                p.Salario = int.Parse(this.reader["SALARIO"].ToString());
                listaplantilla.Add(p);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listaplantilla;
        }

        public List<Doctor> GetDoctoresHospital(int idhospital)
        {
            String sql = "select * from doctor where hospital_cod=@idhospital";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@idhospital", idhospital);
            this.com.Parameters.Add(pamid);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Doctor> listadoctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
                listadoctores.Add(doc);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listadoctores;
        }
    }
}
