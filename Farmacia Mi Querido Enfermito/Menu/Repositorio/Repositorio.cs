
using Menu.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repositorio
{
   public class Repositorio
    {

        EmpleadoCruud accionesArchivo;
        List<EmpleadoClasess> empleado;
        public Repositorio()
        {
            accionesArchivo = new EmpleadoCruud("Categorias.poo");
            empleado = new List<EmpleadoClasess>();
        }

        public bool Agregar(EmpleadoClasess inv)
        {
            empleado.Add(inv);
            bool accion = ActualizarArchivo();
            empleado = Leer();
            return accion;
        }

        private bool ActualizarArchivo()
        {
            string elementos = "";
            foreach (EmpleadoClasess item in empleado)
            {
                elementos += string.Format("{0}| {1}\n", item.sexo, item.Edad);
            }
            return accionesArchivo.Guardar(elementos);
        }

        public List<EmpleadoClasess> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<EmpleadoClasess> inv = new List<EmpleadoClasess>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    EmpleadoClasess a = new EmpleadoClasess();
                    a.sexo = (espacio[0]);
                    a.Edad = espacio[1];

                    inv.Add(a);
                }
                empleado = inv;
                return inv;
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar(EmpleadoClasess cat)
        {
            EmpleadoClasess categori = new EmpleadoClasess();
            foreach (var Buscador in empleado)
            {
                if (Buscador.Edad == cat.Edad)
                {
                    categori = Buscador;
                }
            }
            empleado.Remove(categori);
            bool accion = ActualizarArchivo();
            empleado = Leer();
            return accion;
        }

        public bool Modificar(EmpleadoClasess original, EmpleadoClasess modificado)
        {
            EmpleadoClasess t = new EmpleadoClasess();
            foreach (var buscador in empleado)
            {
                if (original.sexo == buscador.sexo)
                {
                    t = buscador;
                }
            }
            t.sexo = modificado.sexo;
            t.Edad = modificado.Edad;
            bool resultado = ActualizarArchivo();
            empleado = Leer();
            return resultado;
        }


    }
}
