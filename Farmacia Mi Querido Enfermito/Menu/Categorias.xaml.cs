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
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {
        RepositorioCategorias repositorio;
        bool esNuevo;
        public Categorias()
        {
            InitializeComponent();
            repositorio = new RepositorioCategorias();
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
            NombreCategorias.Clear();
            NombreCategorias.IsEnabled = habilitadas;

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
                MessageBox.Show("Error", "No tienes categorias", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (CategoriasTabla.SelectedItem != null)
                {
                    ClaseCategorias a = CategoriasTabla.SelectedItem as ClaseCategorias;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.NombreCategoria + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.Eliminar(a))
                        {
                            MessageBox.Show("Tu categoria ha sido removida", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar tu categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NombreCategorias.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                ClaseCategorias a = new ClaseCategorias();

                a.NombreCategoria = NombreCategorias.Text;

                if (repositorio.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar tu categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ClaseCategorias original = CategoriasTabla.SelectedItem as ClaseCategorias;
                ClaseCategorias a = new ClaseCategorias();
                a.NombreCategoria = NombreCategorias.Text;
                if (repositorio.Modificar(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Tu Categoria a sido actualizada", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar tu Categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            CategoriasTabla.ItemsSource = null;
            CategoriasTabla.ItemsSource = repositorio.Leer();
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
                MessageBox.Show("Error", "No tienes Categorias", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (CategoriasTabla.SelectedItem != null)
                {
                    ClaseCategorias a = CategoriasTabla.SelectedItem as ClaseCategorias;
                    HabilitarCajas(true);
                    NombreCategorias.Text = a.NombreCategoria;

                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
