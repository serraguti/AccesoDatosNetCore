using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosNetCore.Models
{
    public class Bicicleta
    {
        public String Marca { get; set; }
        public String Imagen { get; set; }

        public int VelocidadActual { get; set; }

        public int Aceleracion { get; set; }
        public Bicicleta(string marca, string imagen, int velocidad, int aceleracion)
        {
            this.Marca = marca;
            this.Imagen = imagen;
            this.Aceleracion = aceleracion;
            this.VelocidadActual = velocidad;
        }

        public int Acelerar()
        {
            this.VelocidadActual = this.VelocidadActual + this.Aceleracion;
            return this.VelocidadActual;
        }

        public int Frenar()
        {
            this.VelocidadActual = this.VelocidadActual - 5;
            if (this.VelocidadActual < 0)
            {
                this.VelocidadActual = 0;
            }
            return this.VelocidadActual;
        }
    }
}
