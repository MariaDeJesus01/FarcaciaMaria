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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        RepositorioProductos  repositorio;
        bool esNuevo;
        public Productos()
        {
            InitializeComponent();
            repositorio = new RepositorioProductos();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            NombreMedicamento.Clear();
            Descripcion.Clear();
            PrecioCompra.Clear();
            PrecioVenta.Clear();
            Presentacion.Clear();
            NombreMedicamento.IsEnabled = habilitadas;
            Descripcion.IsEnabled = habilitadas;
            PrecioCompra.IsEnabled = habilitadas;
            PrecioVenta.IsEnabled = habilitadas;
            Presentacion.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void btnRegresar_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leer().Count == 0)
            {
                MessageBox.Show("Error", "No tienes Productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ProductosTabla.SelectedItem != null)
                {
                    ClaseProductos a = ProductosTabla.SelectedItem as ClaseProductos;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.Eliminar(a))
                        {
                            MessageBox.Show("Tu Producto ha sido removido", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar tu Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Productos", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NombreMedicamento.Text) || string.IsNullOrEmpty(Descripcion.Text) || string.IsNullOrEmpty(PrecioCompra.Text) || string.IsNullOrEmpty(PrecioVenta.Text) || string.IsNullOrEmpty(Presentacion.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                ClaseProductos a = new ClaseProductos();

                a.Nombre = NombreMedicamento.Text;
                a.Descripcion = Descripcion.Text;
                a.PrecioDeCompra = PrecioCompra.Text;
                a.PrecioDeVenta = PrecioVenta.Text;
                a.Presentacion = Presentacion.Text;

                if (repositorio.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ClaseProductos original = ProductosTabla.SelectedItem as ClaseProductos;
                ClaseProductos a = new ClaseProductos();
                a.Nombre = NombreMedicamento.Text;
                a.Descripcion = Descripcion.Text;
                a.PrecioDeCompra = PrecioCompra.Text;
                a.PrecioDeVenta = PrecioVenta.Text;
                a.Presentacion = Presentacion.Text;
                if (repositorio.Modificar (original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Tu Producto a sido actualizado", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            ProductosTabla.ItemsSource = null;
            ProductosTabla.ItemsSource = repositorio.Leer();
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
                MessageBox.Show("Error", "No tienes Productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ProductosTabla.SelectedItem != null)
                {
                    ClaseProductos a = ProductosTabla.SelectedItem as ClaseProductos;
                    HabilitarCajas(true);
                    NombreMedicamento.Text = a.Nombre;
                    a.Descripcion = Descripcion.Text;
                    a.PrecioDeCompra = PrecioCompra.Text;
                    a.PrecioDeVenta = PrecioVenta.Text;
                    a.Presentacion = Presentacion.Text;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Productos", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
