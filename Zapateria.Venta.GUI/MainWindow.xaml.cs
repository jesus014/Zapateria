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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zapateria.BIZ;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;
using Zapateria.DAL;

namespace Zapateria.Venta.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorEmpleado manejadorEmpleados;
        IManejadorClientes manejadorClientes;
        IManejadorProducto manejadorProductos;
        IManejadorEstadistico manejadorEstadistico;

        public MainWindow()
        {
            InitializeComponent();
            manejadorProductos = new ManejadorProducto(new RepositorioProductos());
            manejadorEmpleados = new ManejadorEmpleados(new RepositorioEmpleados());
            manejadorClientes = new ManejadorClientes(new RepositorioClientes());
            manejadorEstadistico = new ManejadorEstadistico(new RepositorioEstadisticos());

            ActualizarCombos();
            ActualizarTablaVenta();
        }

        private void ActualizarTablaVenta()
        {
            dtgTablaw.ItemsSource = null;
            dtgTablaw.ItemsSource = manejadorEstadistico.Listar;
        }

        private void ActualizarCombos()
        {
            cmbCliente.ItemsSource = null;
            cmbCliente.ItemsSource = manejadorClientes.Listar;

            cmbProducto.ItemsSource = null;
            cmbProducto.ItemsSource = manejadorProductos.Listar;

            cmbVendedor.ItemsSource = null;
            cmbVendedor.ItemsSource = manejadorEmpleados.Listar;
        }
        private void HabilitarCampos(bool v)
        {
            btnAceptar.IsEnabled = !v;
            btnSalir.IsEnabled = !v;
            btnNuevo.IsEnabled = v;
            btnEliminar.IsEnabled = v;
            btnCalcularPagar.IsEnabled = !v;

            cmbCliente.IsEnabled = !v;
            cmbProducto.IsEnabled = !v;
            cmbVendedor.IsEnabled = !v;
            txbCambio.IsEnabled = !v;
            txbTotalPagar.IsEnabled = !v;

        }

        private void LimpiarCampos()
        {
            cmbVendedor.Text = "";
            cmbProducto.Text = "";
            cmbCliente.Text = "";
            txbTotalPagar.Clear();
            txbCambio.Clear();

        }

        private void btnCalcularPagar_Click(object sender, RoutedEventArgs e)
        {


        }

        private void txbCalcular_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);

        }

     

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
           Estadisticos  za = dtgTablaw.SelectedItem as Estadisticos;
            if (za != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta venta", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEstadistico.Delete(za.Id))
                    {
                        MessageBox.Show("ventae eliminada", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaVenta();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la venta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow v = new MainWindow();
            this.Close();

        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
