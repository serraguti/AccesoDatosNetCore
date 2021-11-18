using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosNetCore.Models;

namespace AccesoDatosNetCore.Data
{
    public class EmpleadosContext
    {
        //AQUI DECLARAMOS LOS OBJETOS DE ACCESO A DATOS
        private SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        //EN EL CONSTRUCTOR, INSTANCIAMOS LOS OBJETOS
        //DE ACCESO A DATOS
        //PARA CONSTRUIR UN CONTEXTO, DEBEN DARME
        //LA CADENA DE CONEXION
        public EmpleadosContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //AQUI TENDRIAMOS TODOS LOS METODOS QUE VAYAMOS A REALIZAR
        //SOBRE LA BBDD
        //EN ESTE EJEMPLO, QUEREMOS UN METODO PARA DEVOLVER
        //TODOS LOS EMPLEADOS List<Empleado>
        public List<Empleado> GetEmpleados()
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
            //DESPUES DE CERRAR LA CONEXION, DEVOLVEMOS LOS EMPLEADOS
            return listaempleados;
        }

        public Empleado BuscarEmpleado(int idempleado)
        {
            string sql = "select * from emp where emp_no=@empno";
            this.com.CommandText = sql;
            SqlParameter pamempno = new SqlParameter("@empno", idempleado);
            this.com.Parameters.Add(pamempno);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            Empleado empleado;
            if (this.reader.Read())
            {
                empleado = new Empleado();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
            }
            else
            {
                empleado = null;
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleado;
        }

        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            String sql = "select * from emp where salario > @salario";
            this.com.CommandText = sql;
            SqlParameter pamsalario = new SqlParameter("@salario", salario);
            this.com.Parameters.Add(pamsalario);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> listaempleados = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
                listaempleados.Add(empleado);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            if (listaempleados.Count == 0)
            {
                return null;
            }
            else
            {
                return listaempleados;
            }
        }

        public List<string> GetOficios()
        {
            String sql = "select distinct oficio from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<string> listaoficios = new List<string>();
            while (this.reader.Read())
            {
                String oficio = this.reader["OFICIO"].ToString();
                listaoficios.Add(oficio);
            }

            this.reader.Close();
            this.cn.Close();
            return listaoficios;
        }

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            String sql = "select * from emp where oficio=@oficio";
            this.com.CommandText = sql;
            SqlParameter pamoficio = new SqlParameter("@oficio", oficio);
            this.com.Parameters.Add(pamoficio);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> listaempleados = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
                listaempleados.Add(empleado);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listaempleados;
        }
    }
}
