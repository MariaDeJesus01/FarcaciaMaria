using Menu.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Menu
{
    /// <summary>
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class Empleado : Window
    {
        Repositorio repositorio;
        bool esNuevo;
        public Empleado()
        {
            InitializeComponent();
            repositorio = new Repositorio();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void btnRegresar_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); 

        }

        private void HabilitarCajas(bool habilitadas)
        {
            NombreEmpleado.Clear();
            Edad.Clear();
            Sexo.Clear();
            NombreEmpleado.IsEnabled = habilitadas;
            Edad.IsEnabled = habilitadas;
            Sexo.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
 
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leer().Count == 0)
            {
                MessageBox.Show("Error", "No tienes Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (EmpleadosTabla.SelectedItem != null)
                {
                    EmpleadoClasess a = EmpleadosTabla.SelectedItem as EmpleadoClasess;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.Eliminar(a))
                        {
                            MessageBox.Show("Tu Empleado ha sido removido", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleados", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NombreEmpleado.Text) || string.IsNullOrEmpty(Edad.Text) || string.IsNullOrEmpty(Sexo.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                EmpleadoClasess a = new EmpleadoClasess();

                a.Nombre = NombreEmpleado.Text;
                a.Edad = Edad.Text;
                a.sexo = Sexo.Text;

                if (repositorio.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                EmpleadoClasess original = EmpleadosTabla.SelectedItem as EmpleadoClasess;
                EmpleadoClasess a = new EmpleadoClasess();
                a.Nombre = NombreEmpleado.Text;
                a.Edad = Edad.Text;
                a.sexo = Sexo.Text;
                if (repositorio.Modificar(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Tu Empleado a sido actualizado", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            EmpleadosTabla.ItemsSource = null;
            EmpleadosTabla.ItemsSource = repositorio.Leer();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leer().Count == 0)
            {
                MessageBox.Show("Error", "No tienes Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (EmpleadosTabla.SelectedItem != null)
                {
                    EmpleadoClasess a = EmpleadosTabla.SelectedItem as EmpleadoClasess;
                    HabilitarCajas(true);
                    NombreEmpleado.Text = a.Nombre;
                    Sexo.Text = a.sexo;
                    Edad.Text = a.Edad;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleados", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }
    }
}