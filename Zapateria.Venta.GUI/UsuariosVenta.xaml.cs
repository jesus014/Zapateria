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
using Zapateria.Venta.GUI;
using Zapateria.Venta.GUI.Contrasenia2;

namespace Zapateria.Venta.GUI
{
    /// <summary>
    /// Lógica de interacción para UsuariosExistencia.xaml
    /// </summary>
    public partial class UsuariosVenta : Window
    {
        public UsuariosVenta()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            AdministradorConstrasenia2 contrasena = new AdministradorConstrasenia2();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                ModificacionConstrasenias2 v = new ModificacionConstrasenias2();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            AdministradorConstrasenia2 v = new AdministradorConstrasenia2();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministradorConstrasenia2 constrasenia2 = new AdministradorConstrasenia2();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;
            if (contrasenaIngresada == constrasenia2.contrasena() && usuarioIngresada == constrasenia2.usuario())
            {
                MainWindow v = new MainWindow();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();

            }

        }
    }
}
