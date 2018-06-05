﻿using System;
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
using Zapateria.Adminitracion.GUI.Contrasenia;

namespace Zapateria.Adminitracion.GUI
{
    /// <summary>
    /// Lógica de interacción para ModificacionContrasenias.xaml
    /// </summary>
    public partial class ModificacionContrasenias : Window
    {
        public ModificacionContrasenias()
        {
            InitializeComponent();
        }

        private void GuardarContrasena_Click(object sender, RoutedEventArgs e)
        {
            Generar archivo = new Generar();
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
                    if (archivo.Genrar(usuario, contrasena))
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
            AdministradorContrasenia v = new AdministradorContrasenia();
            //v.Show();
            this.Close();

        }

    }
}
