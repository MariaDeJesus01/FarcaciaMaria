using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repositoriosk
{
   public class RepositorioCliente
    {
        EmpleadoCruud accionesArchivo;
        List<ClaseCliente> clientes;
        public RepositorioCliente()
        {
            accionesArchivo = new EmpleadoCruud("Clientes.poo");
            clientes = new List<ClaseCliente>();
        }

        public bool Agregar(ClaseCliente inv)
        {
            clientes.Add(inv);
            bool accion = ActualizarArchivo();
            clientes = Leer();
            return accion;
        }

        private bool ActualizarArchivo()
        {
            string elementos = "";
            foreach (ClaseCliente item in clientes)
            {
                elementos += string.Format("{0}| {1} | {2} | {3} | {4}\n", item.Nombre, item.Direccion, item.RFC, item.Telefono, item.Email);
            }
            return accionesArchivo.Guardar(elementos);
        }

        public List<ClaseCliente> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<ClaseCliente> inv = new List<ClaseCliente>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    ClaseCliente a = new ClaseCliente();
                    a.Nombre = (espacio[0]);
                    a.Direccion = (espacio[1]);
                    a.RFC = (espacio[2]);
                    a.Telefono = (espacio[3]);
                    a.Email = (espacio[4]);

                    inv.Add(a);
                }
                clientes = inv;
                return inv;
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar(ClaseCliente cat)
        {
            ClaseCliente categori = new ClaseCliente();
            foreach (var Buscador in clientes)
            {
                if (Buscador.Nombre == cat.Nombre)
                {
                    categori = Buscador;
                }
            }
            clientes.Remove(categori);
            bool accion = ActualizarArchivo();
            clientes = Leer();
            return accion;
        }

        public bool Modificar(ClaseCliente original, ClaseCliente modificado)
        {
            ClaseCliente t = new ClaseCliente();
            foreach (var buscador in clientes)
            {
                if (original.Nombre == buscador.Nombre)
                {
                    t = buscador;
                }
            }
            t.Nombre = modificado.Nombre;
            t.Direccion = modificado.Direccion;
            t.RFC = modificado.RFC;
            t.Telefono = modificado.Telefono;
            t.Email = modificado.Email;
            bool resultado = ActualizarArchivo();
            clientes = Leer();
            return resultado;
        }

    }
}
