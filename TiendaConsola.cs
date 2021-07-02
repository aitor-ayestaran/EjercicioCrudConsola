using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioCrudConsola.Entidades;
namespace EjercicioCrudConsola.Presentacion
{
    public class TiendaConsola
    {
        public static void Main()
        {           
            bool stop = false;
            int opcion;
            Tienda tienda = new Tienda();

            #region Datos iniciales
            var p1 = new Producto("Boli", 2.5M);
            var p2 = new Producto("Lápiz", 1.5M);
            var p3 = new Producto("Cuaderno", 4);
            tienda.Agregar(p1);
            tienda.Agregar(p2);
            tienda.Agregar(p3);
            #endregion

            Console.WriteLine("Bienvenido a la aplicación de la tienda.");
            do
            {
                opcion = Menu();
                switch (opcion)
                {
                    case 0: 
                        stop = true;
                        break;
                    case 1:
                        ListarProductos(tienda);
                        break;
                    case 2:
                        AgregarProducto(tienda);               
                        break;
                    case 3:
                        ModificarProducto(tienda);        
                        break;
                    case 4:
                        EliminarProducto(tienda);                     
                        break;
                }
            }
            while (!stop);
            Console.WriteLine("Adios. ");
        }
        private static int Menu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n1.- Listar productos\n2.- Añadir un producto\n3.- Modificar producto\n4.- Eliminar producto\n0.- Salir");
                opcion = PedirEntero("Escoge la operación: ");
                if (opcion < 0 || opcion > 4)
                {
                    Console.WriteLine("Entrada no válida. Debe escoger una opción de 0 a 4");
                }
            }
            while (opcion < 0 || opcion > 4);
            return opcion;
        }
        private static void ListarProductos(Tienda tienda)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nId; Nombre; Precio");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var producto in tienda.Productos)
            {
                Console.WriteLine(producto);
            }
        }
        private static void AgregarProducto(Tienda tienda)
        {
            Console.Write("Nombre del nuevo producto: ");
            string nombre = Console.ReadLine();
            decimal precio = PedirDecimal($"Precio de {nombre}: ");
            Producto producto = (new Producto(nombre, precio));
            tienda.Agregar(producto);            
        }
        private static void ModificarProducto(Tienda tienda)
        {
            int id = PedirEntero("Introduce la Id del producto a modificar: ");
            bool existe = tienda.ComprobarId(id);
            if (existe)
            {
                Producto producto = tienda.ObtenerProducto(id);
                Console.WriteLine(producto);
                Console.Write("Desea modificar el nombre?: ");
                if (PreguntarSiNo())
                {
                    Console.Write("Introduzca el nuevo nombre: ");
                    //producto.Nombre = Console.ReadLine();
                    tienda.Editar(id, "nombre", Console.ReadLine());
                }
                Console.Write("Desea modificar el precio?: ");
                if (PreguntarSiNo())
                {
                    //producto.Precio = PedirDecimal("Introduzca el nuevo precio: ");
                    tienda.Editar(id, "precio", PedirDecimal("Introduzca el nuevo precio: ").ToString());
                }
            }
            else
            {
                Console.WriteLine($"La Id {id} no corresponde a ningún producto.");
            }
        }
        private static void EliminarProducto(Tienda tienda)
        {
            int id = PedirEntero("Introduce el Id del producto a eliminar: ");
            if (tienda.EliminarPorId(id))
            {
                Console.WriteLine("Producto eliminado correctamente. ");
            }
            else
            {
                Console.WriteLine("No hay ningún producto con esa Id. ");
            }
        }

        #region Funciones de entrada de datos
        private static bool PreguntarSiNo()
        {
            string respuesta;
            do
            {
                Console.Write("(S/N): ");
                respuesta = Console.ReadLine().Trim().ToUpper();

            }
            while (respuesta != "S" && respuesta != "N");

            return respuesta == "S";
        }

        private static decimal PedirDecimal(string texto)
        {
            bool esValido;
            decimal numero;
            do
            {
                Console.Write(texto);
                string numeroString = Console.ReadLine();
                numeroString = numeroString.Replace(".", ",");
                esValido = decimal.TryParse(numeroString, out numero);
                if (!esValido) { Console.Write(numeroString + " no es un decimal válido. "); }
            }
            while (!esValido);
            return numero;
        }
        private static int PedirEntero(string texto)
        {
            bool esValido;
            int numero;
            do
            {
                Console.Write(texto);
                string numeroString = Console.ReadLine();
                esValido = int.TryParse(numeroString, out numero);
                if (!esValido) { Console.Write(numeroString + " no es un entero válido. "); }
            }
            while (!esValido);
            return numero;
        }
        #endregion
    }
}