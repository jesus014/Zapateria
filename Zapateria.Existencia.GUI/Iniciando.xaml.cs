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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zapateria.Existencia.GUI
{
    /// <summary>
    /// Lógica de interacción para Iniciando.xaml
    /// </summary>
    public partial class Iniciando : Window
    {
        public Iniciando()
        {
            InitializeComponent();
            CargandoProgreso();
            pb1.ValueChanged += pb1_EvaluarProgreso;
        }

        private void pb1_EvaluarProgreso(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pb1.Value == 100)
            {
                UsuariosExistencia v = new UsuariosExistencia();
                v.Show();
                this.Close();
            }
        }

        private void CargandoProgreso()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation animacion = new DoubleAnimation(200.0, dur);
            pb1.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, animacion);
        }
    }
}
