using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Models
{
    public class Enfermo
    {
        public int Inscripcion { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String FechaNacimiento { get; set; }
    }
}
