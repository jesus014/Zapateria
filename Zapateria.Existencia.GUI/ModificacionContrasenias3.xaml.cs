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
    /// Lógica de interacción para ModificacionContrasenias3.xaml
    /// </summary>
    public partial class ModificacionContrasenias3 : Window
    {
        public ModificacionContrasenias3()
        {
            InitializeComponent();
        }

        private void GuardarContrasena_Click(object sender, RoutedEventArgs e)
        {
            Generar3 archivo = new Generar3();
            string usuario;
            string contrasena;
            string contrasena2;
            usuario = txbNuevoUsuario.Text;
            contrasena = txbNuevaContrasena.Text;
            contrasena2 = txbNuevaContrasena2.Text;
            try
            {


                if (contrasena == contrasena2)
                {
                    if (archivo.Genrar3(usuario, contrasena))
                    {
                        MessageBox.Show("Usuario y Contraseña modificado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Usuario y Contraseña no se pudo modificar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no son iguales", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            AdministradorContrasenia3 v = new AdministradorContrasenia3();
            this.Close();
        }
    }
}
