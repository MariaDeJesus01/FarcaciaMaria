using Menu.Repositoriosk;
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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        RepositorioCliente repositorio;
        bool esNuevo;
        public Clientes()
        {
            InitializeComponent();
            repositorio = new RepositorioCliente();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            Nombre.Clear();
            Direccion.Clear();
            RFC.Clear();
            Telefono.Clear();
            Email.Clear();
            Nombre.IsEnabled = habilitadas;
            Direccion.IsEnabled = habilitadas;
            Telefono.IsEnabled = habilitadas;
            Email.IsEnabled = habilitadas;
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
                MessageBox.Show("Error", "No tienes Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ClienteTabla.SelectedItem != null)
                {
                    ClaseCliente a = ClienteTabla.SelectedItem as ClaseCliente;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.Eliminar(a))
                        {
                            MessageBox.Show("Tu Cliente ha sido removido", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar tu Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Clientes", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Nombre.Text) || string.IsNullOrEmpty(Direccion.Text) || string.IsNullOrEmpty(RFC.Text) || string.IsNullOrEmpty(Telefono.Text) || string.IsNullOrEmpty(Email.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                ClaseCliente a = new ClaseCliente();

                a.Nombre = Nombre.Text;
                a.Direccion = Direccion.Text;
                a.RFC = RFC.Text;
                a.Telefono = Telefono.Text;
                a.Email = Email.Text;

                if (repositorio.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar tu Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ClaseCliente original = ClienteTabla.SelectedItem as ClaseCliente;
                ClaseCliente a = new ClaseCliente();
                a.Nombre = Nombre.Text;
                a.Direccion = Direccion.Text;
                a.RFC = RFC.Text;
                a.Telefono = Telefono.Text;
                a.Email = Email.Text;
                if (repositorio.Modificar(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Tu Cliente a sido actualizado", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            ClienteTabla.ItemsSource = null;
            ClienteTabla.ItemsSource = repositorio.Leer();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leer().Count == 0)
            {
                MessageBox.Show("Error", "No tienes Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ClienteTabla.SelectedItem != null)
                {
                    ClaseCliente a = ClienteTabla.SelectedItem as ClaseCliente;
                    HabilitarCajas(true);
                    Nombre.Text = a.Nombre;
                    Direccion.Text = a.Direccion;
                    RFC.Text = a.RFC;
                    RFC.Text = a.RFC;
                    RFC.Text = a.RFC;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Clientes", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
