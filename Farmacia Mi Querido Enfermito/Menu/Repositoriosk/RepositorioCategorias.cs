using Menu.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repositoriosk
{
    public class RepositorioCategorias
    {
        EmpleadoCruud accionesArchivo;
        List<ClaseCategorias> categorias;
        public RepositorioCategorias()
        {
            accionesArchivo = new EmpleadoCruud("Categorias.poo");
            categorias = new List<ClaseCategorias>();
        }

        public bool Agregar(ClaseCategorias inv)
        {
            categorias.Add(inv);
            bool accion = ActualizarArchivo();
            categorias = Leer();
            return accion;
        }

        private bool ActualizarArchivo()
        {
            string elementos = "";
            foreach (ClaseCategorias item in categorias)
            {
                elementos += string.Format("{0}\n", item.NombreCategoria);
            }
            return accionesArchivo.Guardar(elementos);
        }

        public List<ClaseCategorias> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<ClaseCategorias> inv = new List<ClaseCategorias>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    ClaseCategorias a = new ClaseCategorias();
                    a.NombreCategoria = (espacio[0]);

                    inv.Add(a);
                }
                categorias = inv;
                return inv;
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar(ClaseCategorias cat)
        {
            ClaseCategorias categori = new ClaseCategorias();
            foreach (var Buscador in categorias)
            {
                if (Buscador.NombreCategoria == cat.NombreCategoria)
                {
                    categori = Buscador;
                }
            }
            categorias.Remove(categori);
            bool accion = ActualizarArchivo();
            categorias = Leer();
            return accion;
        }

        public bool Modificar(ClaseCategorias original, ClaseCategorias modificado)
        {
            ClaseCategorias t = new ClaseCategorias();
            foreach (var buscador in categorias)
            {
                if (original.NombreCategoria == buscador.NombreCategoria)
                {
                    t = buscador;
                }
            }
            t.NombreCategoria = modificado.NombreCategoria;
            bool resultado = ActualizarArchivo();
            categorias = Leer();
            return resultado;
        }
    }
}
