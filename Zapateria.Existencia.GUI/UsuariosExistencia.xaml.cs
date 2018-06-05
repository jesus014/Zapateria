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
using Zapateria.Existencia.GUI.Contrasenia3;

namespace Zapateria.Existencia.GUI
{
    /// <summary>
    /// Lógica de interacción para UsuariosExistencia.xaml
    /// </summary>
    public partial class UsuariosExistencia : Window
    {
        public UsuariosExistencia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            AdministradorContrasenia3 v = new AdministradorContrasenia3();
            this.Close();

        }

        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            AdministradorContrasenia3 contrasena = new AdministradorContrasenia3();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                ModificacionContrasenias3 v = new ModificacionContrasenias3();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministradorContrasenia3 constrasenia2 = new AdministradorContrasenia3();
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
