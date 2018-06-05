using Microsoft.Reporting.WinForms;
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
using Zapateria.COMMON.Interfaz;
using Zapateria.COMMON.Modelos;
using Zapateria.DAL;

namespace Zapateria.Existencia.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorEmpleado manejadorEmpleados;
        IManejadorProducto manejadorProducto;

        public MainWindow()
        {
            InitializeComponent();
            manejadorEmpleados = new ManejadorEmpleados(new RepositorioEmpleados());
            manejadorProducto = new ManejadorProducto(new RepositorioProductos());
            ActualizarCombo();
        }

        private void ActualizarCombo()
        {
            cmbEmpleado.ItemsSource = null;
            cmbEmpleado.ItemsSource = manejadorEmpleados.Listar;
            txtBuscarProducto.ItemsSource = null;
            txtBuscarProducto.ItemsSource = manejadorProducto.Listar;
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarTablaEmpleados();

        }


        private void ActualizarTablaEmpleados()
        {
            string d = cmbEmpleado.Text;
            manejadorEmpleados.Empleadoss(d);
            dtgTabla.ItemsSource = manejadorEmpleados.Empleadoss(d);
        }
        private void ActualizarTablaProducto()
        {
            dtgTablaBuscar.ItemsSource = null;
            dtgTablaBuscar.ItemsSource = manejadorProducto.Listar;
        }


        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            dtgTabla.SelectAllCells();
            dtgTabla.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtgTabla);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtgTabla.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter("TrabajoExceL.xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
            MessageBox.Show("Se exporto", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void BuscarEmpleado()
        {
            List<ReportDataSource> datos = new List<ReportDataSource>();
            ReportDataSource vales = new ReportDataSource();
            List<Model> datosTorneo = new List<Model>();
            foreach (var item in manejadorEmpleados.Listar)
            {
                if (item.RFC == txtBuscarEmpleados.Text)
                {
                    datosTorneo.Add(new Model(item));
                }
            }
            vales.Value = datosTorneo;
            vales.Name = "DataSet1";
            datos.Add(vales);
            Reporteador ventana = new Reporteador("Zapateria.Existencia.GUI.Reportes.EmpleadosProductos.rdlc", datos);
            ventana.ShowDialog();
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            BuscarEmpleado();


        }

        private void BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            ActualizarTablaProducto();

        }

       
    }
}
