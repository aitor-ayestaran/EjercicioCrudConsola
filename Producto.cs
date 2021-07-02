using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCrudConsola.Entidades
{
    class Producto
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }
        public Producto(string nombre, decimal precio)
        {
            Id = contador;
            contador++;
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Id}; {Nombre}; {Precio}";
        }

        
    }
}
