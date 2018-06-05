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
using Zapateria.Administracion.GUI;
using Zapateria.Adminitracion.GUI.Contrasenia;

namespace Zapateria.Adminitracion.GUI
{
    /// <summary>
    /// Lógica de interacción para UsuariosAdministrador.xaml
    /// </summary>
    public partial class UsuariosAdministrador : Window
    {
        public UsuariosAdministrador()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            AdministradorContrasenia v = new AdministradorContrasenia();
                this.Close();
            
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            AdministradorContrasenia contrasena = new AdministradorContrasenia();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                ModificacionContrasenias v = new ModificacionContrasenias();
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
            AdministradorContrasenia contrasena = new AdministradorContrasenia();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
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

        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }




    }
}