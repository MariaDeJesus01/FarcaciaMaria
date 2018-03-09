using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repositoriosk
{
    public class RepositorioProductos
    {
        EmpleadoCruud accionesArchivo;
        List<ClaseProductos> productos;
        public RepositorioProductos()
        {
            accionesArchivo = new EmpleadoCruud("Productos.poo");
            productos = new List<ClaseProductos>();
        }

        public bool Agregar(ClaseProductos inv)
        {
            productos.Add(inv);
            bool accion = ActualizarArchivo();
            productos = Leer();
            return accion;
        }

        private bool ActualizarArchivo()
        {
            string elementos = "";
            foreach (ClaseProductos item in productos)
            {
                elementos += string.Format("{0}| {1} | {2} | {3} | {4}\n", item.Nombre, item.Descripcion, item.PrecioDeCompra, item.PrecioDeVenta, item.Presentacion);
            }
            return accionesArchivo.Guardar(elementos);
        }

        public List<ClaseProductos> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<ClaseProductos> inv = new List<ClaseProductos>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    ClaseProductos a = new ClaseProductos();
                    a.Nombre = (espacio[0]);
                    a.Descripcion = (espacio[1]);
                    a.PrecioDeCompra = (espacio[2]);
                    a.PrecioDeVenta = (espacio[3]);
                    a.Presentacion = (espacio[4]);

                    inv.Add(a);
                }
                productos = inv;
                return inv;
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar(ClaseProductos cat)
        {
            ClaseProductos categori = new ClaseProductos();
            foreach (var Buscador in productos)
            {
                if (Buscador.Nombre == cat.Nombre)
                {
                    categori = Buscador;
                }
            }
            productos.Remove(categori);
            bool accion = ActualizarArchivo();
            productos = Leer();
            return accion;
        }

        public bool Modificar(ClaseProductos original, ClaseProductos modificado)
        {
            ClaseProductos t = new ClaseProductos();
            foreach (var buscador in productos)
            {
                if (original.Nombre == buscador.Nombre)
                {
                    t = buscador;
                }
            }
            t.Nombre = modificado.Nombre;
            t.Descripcion = modificado.Descripcion;
            t.PrecioDeCompra = modificado.PrecioDeCompra;
            t.PrecioDeVenta = modificado.PrecioDeVenta;
            t.Presentacion = modificado.Presentacion;
            bool resultado = ActualizarArchivo();
            productos = Leer();
            return resultado;
        }
    }
}
