using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCrudConsola.Entidades
{
    public class Producto
    {
        private static int contadorId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }
        public Producto(string nombre, decimal precio)
        {
            Id = contadorId;
            contadorId++;
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Id}; {Nombre}; {Precio}";
        }

        
    }
}
