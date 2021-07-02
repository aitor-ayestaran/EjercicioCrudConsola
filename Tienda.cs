using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjercicioCrudConsola.Entidades
{
    class Tienda
    {
        private List<Producto> productos = new List<Producto>();

        public IEnumerable<Producto> Productos
        {
            get { return productos; }
        }
        public void Agregar(Producto p)
        {
            productos.Add(p);
        }
        public bool Eliminar(Producto p)
        {
            return productos.Remove(p);
        }
        public bool EliminarPorId(int id)
        {
            foreach(var producto in Productos)
            {
                if(producto.Id == id)
                {
                    return Eliminar(producto);                    
                }
            }
            return false;
        }
        public void Editar(int id, string campo, string valor)
        {
            foreach (var producto in Productos)
            {
                if (producto.Id == id)
                {
                    if (campo.ToLower() == "nombre")
                    {
                        producto.Nombre = valor;
                    }
                    else if(campo.ToLower() == "precio")
                    {
                        decimal precio;                        
                        bool valido = decimal.TryParse(valor, out precio);
                        if (valido) 
                        {
                            producto.Precio = precio; } 
                        else
                        {
                            throw new TiendaException($"{valor} no es un precio válido");
                        }
                    }
                }
            }
        }

        public bool ComprobarId(int id)
        {
            foreach(var producto in productos)
            {
                if(producto.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Producto ObtenerProducto(int id)
        {
            if (!ComprobarId(id))
            {
                throw new TiendaException($"La Id {id} no corresponde a ningún producto.");
            }
            Producto p = new Producto();
            foreach (var producto in productos)
            {
                
                if(producto.Id == id)
                {
                    p = producto;
                }
            }
            return p;
        }

        //public Producto this[int indice] => productos[indice];
        public Producto this[int id] => productos.Find(p => new Regex(id.ToString()).Equals(p.Id.ToString()));

        public Producto this[string nombre] => productos.Find(p => new Regex(nombre).IsMatch(p.Nombre));
        
    }
}
