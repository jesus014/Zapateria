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
using Zapateria.Adminitracion.GUI;
using Zapateria.BIZ;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;
using Zapateria.DAL;

namespace Zapateria.Administracion.GUI
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
        accion operacion;
        IManejadorEmpleado manejadorEmpleados;
        IManejadorPrestamo manejadorPrestamos;
        IManejadorDistribuidores manejadorDistribuidor;
        IManejadorComision manejadorComision;
        IManejadorCargos manejadorCargos;
        IManejadorProducto manejadorProducto;
        IManejadorMarca manejadorMarca;
        IManejadorClientes manejadorClientes;

        public MainWindow()
        {
            InitializeComponent();
            
            manejadorClientes = new ManejadorClientes(new RepositorioClientes());
            manejadorCargos = new ManejadorCargos(new RepositorioCargos());
            manejadorComision = new ManejadorComision(new RepositorioComision());
            manejadorDistribuidor = new ManejadorDistribuidor(new RepositorioDistribuidores());
            manejadorEmpleados = new ManejadorEmpleados(new RepositorioEmpleados());
            manejadorPrestamos = new ManejadorPrestamos(new RepositorioPrestamo());
            manejadorProducto = new ManejadorProducto(new RepositorioProductos());
            manejadorMarca = new ManejadorMarca(new RepositorioMarca());
            HabilitarBotones(false);
            CargarTablas();
            ActualizarCombos();

         
            LimpiarEditarTablasCargos(false);
            LimpiarEditarTablasProductos(false);
            LimpiarEditarTablasEstilosMarcas(false);
            LimpiarEditarTablasDistribuidores(false);
            LimpiarEditarTablasComisiones(false);
            LimpiarEditarTablasPrestamos(false);
            LimpiarEditarTablasClientes(false);
            LimpiarEditarTablasComision(false);
            LimpiarCamposTablasCliente(false);
            LimpiarCamposTablasDistribuidora(false);
            LimpiarCamposTablasMarca(false);
            LimpiarCamposTablasCargo(false);
           
        }
        private void CargarTablas()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = manejadorClientes.Listar.OrderBy(p => p.Nombre);

            dtgComision.ItemsSource = null;
            dtgComision.ItemsSource = manejadorComision.Listar.OrderBy(p => p.Comisionn);

            dtgDistribuidora.ItemsSource = null;
            dtgDistribuidora.ItemsSource = manejadorDistribuidor.Listar.OrderBy(p => p.Distribuidora);

            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar.OrderBy(p => p.Nombre);

            dtgPrestamos.ItemsSource = null;
            dtgPrestamos.ItemsSource = manejadorPrestamos.Listar.OrderBy(p => p.venta);

            dtgCargos.ItemsSource = null;
            dtgCargos.ItemsSource = manejadorCargos.Listar.OrderBy(p => p.TipoCargo);

            dtgMarca.ItemsSource = null;
            dtgMarca.ItemsSource = manejadorMarca.Listar.OrderBy(p => p.marca);

            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = manejadorProducto.Listar.OrderBy(p => p.NombreProducto);

        }

        private void ActualizarCombos()
        {

            txtTipoEstilo.ItemsSource = null;
            txtTipoEstilo.ItemsSource = manejadorMarca.Listar;

            txtProveedor.ItemsSource = null;
            txtProveedor.ItemsSource = manejadorMarca.Listar;

            txtEmpleadoComision.ItemsSource = null;
            txtEmpleadoComision.ItemsSource = manejadorEmpleados.Listar;

            txtTipoMarca.ItemsSource = null;
            txtTipoMarca.ItemsSource = manejadorMarca.Listar;

            txtProveedor.ItemsSource = null;
            txtProveedor.ItemsSource = manejadorDistribuidor.Listar;

            //txtCargoEmpleado.ItemsSource = null;
            //txtCargoEmpleado.ItemsSource = manejadorEmpleados.Listar;

            txtVentaComision.ItemsSource = null;
            txtVentaComision.ItemsSource = manejadorEmpleados.Listar;

            txtEmpleadoPrestamo.ItemsSource = null;
            txtEmpleadoPrestamo.ItemsSource = manejadorEmpleados.Listar;

            txtEmpleadoComision.ItemsSource = null;
            txtEmpleadoComision.ItemsSource = manejadorEmpleados.Listar;


        }


        private void LimpiarEditarTablasClientes(bool v)
        {
            txtNombreCliente.Clear();
            txtApellidoMaternoCliente.Clear();
            txtApellidoPaternoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtDomicilioCliente.Clear();

            btnAgregarCliente.IsEnabled = v;
            btnCancelarCliente.IsEnabled = v;
            btnEditarCliente.IsEnabled = !v;
            btnEliminarCliente.IsEnabled = !v;
            btnNuevoCliente.IsEnabled = v;

        }

        private void LimpiarEditarTablasPrestamos(bool v)
        {

            txtEmpleadoPrestamo.Text = " ";
            txtAbonoDeuda.Clear();
            txtSalarioCargo.Clear();


            btnAgregarPrestamo.IsEnabled = v;
            btnCancelarPrestamo.IsEnabled = v;
            btnEditarPrestamo.IsEnabled = !v;
            btnEliminarPrestamo.IsEnabled = !v;
            btnNuevoPrestamo.IsEnabled = !v;

            txtEmpleadoPrestamo.IsEnabled=v;
            txtAbonoDeuda.IsEnabled=v;
            txtSalarioCargo.IsEnabled=v;


        }

        private void LimpiarEditarTablasComisiones(bool v)
        {
            txtEmpleadoComision.Text = "";
            txtValorComision.Clear();
            txtVentaComision.Text = "";

            btnAgregarComision.IsEnabled = v;
            btnCancelarComision.IsEnabled = v;
            btnEditarComision.IsEnabled = !v;
            btnEliminarComision.IsEnabled = !v;
            btnNuevoComision.IsEnabled = v;


        }

        private void LimpiarCamposTablasCliente(bool v)
        {
            txtNombreCliente.Clear();
            txtApellidoMaternoCliente.Clear();
            txtApellidoPaternoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtDomicilioCliente.Clear();


            txtNombreCliente.IsEnabled = v;
            txtApellidoMaternoCliente.IsEnabled = v;
            txtApellidoPaternoCliente.IsEnabled = v;
            txtTelefonoCliente.IsEnabled = v;
            txtDomicilioCliente.IsEnabled = v;

            btnAgregarCliente.IsEnabled = v;
            btnCancelarCliente.IsEnabled = v;
            btnEditarCliente.IsEnabled = !v;
            btnEliminarCliente.IsEnabled = !v;
            btnNuevoCliente.IsEnabled = !v;


        }


        private void LimpiarEditarTablasDistribuidores(bool v)
        {
            txtNombreDistribuidora.Clear();
            txtTelefonoDistribuidora.Clear();
            txtCorreo.Clear();

            btnAgregarDistribuidora.IsEnabled = v;
            btnCancelarDistribuidora.IsEnabled = v;
            btnEditarDistribuidora.IsEnabled = !v;
            btnEliminarDistribuidora.IsEnabled = !v;
            btnNuevoDistribuidora.IsEnabled = v;


        }
        //Descripcionn==tablasMarcas

        private void LimpiarEditarTablasEstilosMarcas(bool v)
        {
            txtNombreEstilo.Clear();
            txtNombreGenero.Clear();
            txtDescripcionn.Clear();
            txtMarca.Clear();

            btnAgregarMarca.IsEnabled = v;
            btnCancelarMarca.IsEnabled = v;
            btnEditarMarca.IsEnabled = !v;
            btnEliminarMarca.IsEnabled = !v;
            btnNuevoMarca.IsEnabled = v;


        }

        private void LimpiarEditarTablasProductos(bool v)
        {
            txtNombreProducto.Clear();
            txtTipoEstilo.Text = "";
            txtTipoMarca.Text = "";
            txtTallaDisponible.Clear();
            txtCantidad.Clear();
            txtProveedor.Text = "";

            btnAgregarProducto.IsEnabled = v;
            btnCancelarProducto.IsEnabled = v;
            btnEditarProducto.IsEnabled = !v;
            btnEliminarProducto.IsEnabled = !v;
            btnNuevoProducto.IsEnabled = !v;


            txtNombreProducto.IsEnabled=v;
            txtTipoEstilo.IsEnabled = v;
            txtTipoMarca.IsEnabled = v;
            txtTallaDisponible.IsEnabled=v;
            txtCantidad.IsEnabled=v;
            txtProveedor.IsEnabled = v;



        }


        private void LimpiarEditarTablasCargos(bool v)
        {
            txtTituloCargo.Clear();
            txtSalarioCargo.Clear();
            txtDescripcionCargo.Clear();
           // txtTipoDeporteEquipo.ItemsSource = "";

            txtTituloCargo.IsEnabled=v;
            txtSalarioCargo.IsEnabled=v;
            txtDescripcionCargo.IsEnabled=v;
            //txtTipoDeporteEquipo.IsEnabled = v;

            btnAgregarCargo.IsEnabled = v;
            btnCancelarCargo.IsEnabled = v;
            btnEditarCargo.IsEnabled = v;
            btnEliminarCargo.IsEnabled = !v;
            btnNuevoCargo.IsEnabled = !v;



        }

      
       

        


        private void HabilitarBotones(bool v)
        {
          

            btnAgregarEmpleado.IsEnabled = v;
            btnCancelarEmpleado.IsEnabled = v;
            btnEditarEmpleado.IsEnabled = !v;
            btnEliminarEmpeado.IsEnabled = !v;
            btnNuevoEmpleado.IsEnabled = !v;

            txtNombreEmpleado.IsEnabled = v;
            txtRFCEmpleado.IsEnabled = v;
            txtApellidoMaternoEmpleado.IsEnabled = v;
            txtApellidoPaternoEmpleado.IsEnabled = v;
            txtTelefonoEmpleado.IsEnabled = v;

          


        }
        private void LimpiarCamposUsuario()
        {
            txtNombreEmpleado.Clear();
            txtApellidoMaternoEmpleado.Clear();
            txtApellidoPaternoEmpleado.Clear();
            txtTelefonoEmpleado.Clear();
            txtDomicilioEmpleado.Clear();
            txtRFCEmpleado.Clear();

        }



        private void LimpiarCamposTablasCargo(bool a)
        {
            txtTituloCargo.Clear();
            txtSalarioCargo.Clear();
            txtDescripcionCargo.Clear();
            //txtTipoDeporteEquipo.ItemsSource = "";


            txtTituloCargo.IsEnabled = a;
            txtSalarioCargo.IsEnabled = a;
            txtDescripcionCargo.IsEnabled = a;
            // txtTipoDeporteEquipo.IsEnabled =a;

            btnAgregarCargo.IsEnabled = a;
            btnCancelarCargo.IsEnabled = a;
            btnEditarCargo.IsEnabled = !a;
            btnEliminarCargo.IsEnabled = !a;
            btnNuevoCargo.IsEnabled = !a;
        }

        private void LimpiarCamposTablasMarca(bool a)
        {
            txtMarca.Clear();
            txtNombreEstilo.Clear();
            txtNombreGenero.Clear();
            txtDescripcionn.Clear();

            txtMarca.IsEnabled = a;
            txtDescripcionn.IsEnabled = a;
            txtNombreGenero.IsEnabled = a;
            txtNombreEstilo.IsEnabled = a;

            btnAgregarMarca.IsEnabled = a;
            btnCancelarMarca.IsEnabled = a;
            btnEditarMarca.IsEnabled = !a;
            btnEliminarMarca.IsEnabled = !a;
            btnNuevoMarca.IsEnabled = !a;

        }



        private void LimpiarCamposTablasDistribuidora(bool v)
        {
            txtNombreDistribuidora.Clear();
            txtTelefonoDistribuidora.Clear();
            txtCorreo.Clear();

            txtNombreDistribuidora.IsEnabled = v;
            txtTelefonoDistribuidora.IsEnabled = v;
            txtCorreo.IsEnabled = v;

            btnAgregarDistribuidora.IsEnabled = v;
            btnCancelarDistribuidora.IsEnabled = v;
            btnEliminarDistribuidora.IsEnabled = !v;
            btnNuevoDistribuidora.IsEnabled = !v;
            btnEditarDistribuidora.IsEnabled = !v;



        }


        private void LimpiarEditarTablasComision(bool v)
        {
            txtEmpleadoComision.Text = "";
            txtVentaComision.Text = "";
            txtValorComision.Clear();

            txtEmpleadoComision.IsEnabled = v;
            txtValorComision.IsEnabled = v;
            txtVentaComision.IsEnabled = v;

            btnAgregarComision.IsEnabled = v;
            btnCancelarComision.IsEnabled = v;
            btnEditarComision.IsEnabled = !v;
            btnEliminarComision.IsEnabled = !v;
            btnNuevoComision.IsEnabled = !v;
        }

        private void ActualizarTablaEmpleado()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar.OrderBy(p => p.Nombre);
        }

      


        private void btnNuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposUsuario();
            HabilitarBotones(true);
            operacion = accion.Nuevo;

        }

     

        private void btnCancelarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Usuarios", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotones(false);
                LimpiarCamposUsuario();
            }

        }

        private void btnEliminarEmpeado_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Delete(emp.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorEmpleados.Delete(emp.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }


        }



        private void btnEditarEmpleado_Click(object sender, RoutedEventArgs e)
        {

            if (dtgEmpleados != null)
            {
                operacion = accion.Editar;
                HabilitarBotones(true);
                Empleado empl = dtgEmpleados.SelectedItem as Empleado;

               
                txtApellidoMaternoEmpleado.Text = empl.ApellidoMaterno;
                txtApellidoPaternoEmpleado.Text = empl.ApellidoPaterno;
                txtNombreEmpleado.Text = empl.Nombre;
                txtRFCEmpleado.Text = empl.RFC;
                txtDomicilioEmpleado.Text = empl.Domicilio;
                txtTelefonoEmpleado.Text = empl.Telefono;
              


            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }


        private void btnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Empleado a = new Empleado();
                a.Nombre = txtNombreEmpleado.Text.ToUpper();
                a.RFC = txtRFCEmpleado.Text.ToUpper();
                a.ApellidoMaterno = txtApellidoMaternoEmpleado.Text.ToUpper();
                a.ApellidoPaterno = txtApellidoPaternoEmpleado.Text.ToUpper();
                a.Telefono = txtTelefonoEmpleado.Text.ToUpper();
                a.Domicilio = txtDomicilioEmpleado.Text.ToUpper();


                if (manejadorEmpleados.Create(a))
                {
                    MessageBox.Show("Empleado ingresado correctamente", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarCamposUsuario();
                    HabilitarBotones(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }




  





        private void btnNuevoCargo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasCargos(true);

            operacion = accion.Nuevo;

        }



        private void btnAgregarCargo_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Cargos a = new Cargos();

                a.Salario = txtSalarioCargo.Text.ToUpper();

                a.TipoCargo = txtTituloCargo.Text.ToUpper();

                a.Descripcion = txtDescripcionCargo.Text.ToUpper();




                if (manejadorCargos.Create(a))
                {
                    MessageBox.Show("cargo ingresado correctamente", "Cargos", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasCargos(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Cargos", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void btnEditarCargo_Click(object sender, RoutedEventArgs e)
        {
            if (dtgCargos != null)
            {
                Cargos car = dtgCargos.SelectedItem as Cargos;
                operacion = accion.Editar;

                LimpiarEditarTablasCargos(true);
                txtTituloCargo.Text = car.TipoCargo;
                txtSalarioCargo.Text = car.Salario;
                txtDescripcionCargo.Text = car.Descripcion;



            }


            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Cargos", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnEliminarCargo_Click(object sender, RoutedEventArgs e)
        {
            Cargos car = dtgCargos.SelectedItem as Cargos;
            if (car != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorCargos.Delete(car.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorCargos.Delete(car.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }

        private void btnCancelarCargo_Click(object sender, RoutedEventArgs e)
        {

            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Cargos", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasCargos(false);
            }



        }









        private void btnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasProductos(true);

            operacion = accion.Nuevo;


        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Productos a = new Productos();

                a.NombreProducto = txtNombreProducto.Text.ToUpper();
                a.Proveedor = txtProveedor.Text.ToUpper();
                a.TallaDisponible = txtTallaDisponible.Text.ToUpper();
                a.Marca = txtMarca.Text.ToUpper();
                a.Estilo = txtDescripcionn.Text.ToUpper();
                a.Cantidad = txtCantidad.Text.ToUpper();




                if (manejadorProducto.Create(a))
                {
                    MessageBox.Show("Producto ingresado correctamente", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasProductos(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Cargos", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }

        private void btnEditarProducto_Click(object sender, RoutedEventArgs e)
        {

            if (dtgProductos.SelectedItem != null)
            {
                operacion = accion.Editar;
                LimpiarEditarTablasProductos(true);

                Productos pro = dtgProductos.SelectedItem as Productos;
                txtCantidad.Text = pro.Cantidad;
                txtNombreProducto.Text = pro.NombreProducto;
                txtProveedor.Text = pro.Proveedor;
                txtTallaDisponible.Text = pro.TallaDisponible;
                txtCantidad.Text = pro.Cantidad;
                txtNombreEstilo.Text = pro.Estilo;
              


            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Producto", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            Productos pro = dtgProductos.SelectedItem as Productos;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorProducto.Delete(pro.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorProducto.Delete(pro.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }


        private void btnCancelarProducto_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Cargos", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                
                LimpiarEditarTablasProductos(false);
            }

        }




       



        private void btnNuevoMarca_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasMarca(true);

            operacion = accion.Nuevo;

        }



        private void btnAgregarMarca_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Marca a = new Marca();
                a.marca = txtTipoMarca.Text.ToUpper();
                a.DescripcionMarca = txtDescripcionn.Text.ToUpper();
                a.Estilo = txtNombreEstilo.Text.ToUpper();
                a.Genero = txtNombreGenero.Text.ToUpper();





                if (manejadorMarca.Create(a))
                {
                    MessageBox.Show("Producto ingresado correctamente", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarCamposTablasMarca(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Cargos", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }

        private void btnEditarMarca_Click(object sender, RoutedEventArgs e)
        {



          
            if (dtgMarca.SelectedItem != null)
            {
                operacion = accion.Editar;
                LimpiarCamposTablasMarca(true);
                Marca Mar = dtgMarca.SelectedItem as Marca;
                txtNombreEstilo.Text = Mar.Estilo;
                txtNombreGenero.Text = Mar.Genero;
                txtDescripcionn.Text = Mar.DescripcionMarca;
                txtMarca.Text = Mar.marca;

            



            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Producto", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void btnEliminarMarca_Click(object sender, RoutedEventArgs e)
        {
            Marca mar = dtgMarca.SelectedItem as Marca;
            if (mar != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorMarca.Delete(mar.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorMarca.Delete(mar.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }

        private void btnCancelarMarca_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Cargos", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarCamposTablasMarca(false);
            }

        }










        private void btnNuevoDistribuidora_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasDistribuidora(true);
   
            operacion = accion.Nuevo;

        }


        private void btnAgregarDistribuidora_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Distribuidores a = new Distribuidores();
                a.Distribuidora = txtNombreDistribuidora.Text.ToUpper();
                a.Correo = txtCorreo.Text.ToUpper();
                a.Telefono = txtTelefonoDistribuidora.Text.ToUpper();





                if (manejadorDistribuidor.Create(a))
                {
                    MessageBox.Show("Distribuidor ingresado correctamente", "Distribuidor", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarCamposTablasDistribuidora(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Distribuidor", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void btnEditarDistribuidora_Click(object sender, RoutedEventArgs e)
        {
           
            if (dtgDistribuidora.SelectedItem != null)
            {
                operacion = accion.Editar;
                LimpiarCamposTablasDistribuidora(true);

                Distribuidores Dis = dtgDistribuidora.SelectedItem as Distribuidores;
                txtTelefonoDistribuidora.Text = Dis.Telefono;
                txtCorreo.Text = Dis.Correo;
                txtNombreDistribuidora.Text = Dis.Distribuidora;


            



            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Distribuidora", "Distribuidora", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnEliminarDistribuidora_Click(object sender, RoutedEventArgs e)
        {
            Distribuidores dis = dtgDistribuidora.SelectedItem as Distribuidores;
            if (dis != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDistribuidor.Delete(dis.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorDistribuidor.Delete(dis.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }






        private void btnAgregarComision_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Comision a = new Comision();
                a.Comisionn = txtEmpleadoComision.Text.ToUpper();
                a.valor = txtValorComision.Text.ToUpper();
                a.valor = txtVentaComision.Text.ToUpper();

          
                if (manejadorComision.Create(a))
                {
                    MessageBox.Show("Comision ingresado correctamente", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                   
                    LimpiarEditarTablasComision(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Comision", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }


        private void btnEditarComision_Click(object sender, RoutedEventArgs e)
        {
 
            if (dtgComision.SelectedItem != null)
            {
                operacion = accion.Editar;
                LimpiarEditarTablasComision(true);
                Comision com = dtgComision.SelectedItem as Comision;
                txtVentaComision.Text = com.venta;
                txtValorComision.Text = com.valor;
                txtEmpleadoComision.Text = com.Comisionn;

               



            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Comision", "Comision", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnEliminarComision_Click(object sender, RoutedEventArgs e)
        {
            Comision cos = dtgComision.SelectedItem as Comision;
            if (cos != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorComision.Delete(cos.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorComision.Delete(cos.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }

        private void btnCancelarComision_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasComision(false);
            }

        }

        private void btnNuevoComision_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasComision(true);
                operacion = accion.Nuevo;

        }







        private void btnNuevoPrestamo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasPrestamos(true);
          
            operacion = accion.Nuevo;
        }

        private void btnAgregarPrestamo_Click(object sender, RoutedEventArgs e)
        {

            if (operacion == accion.Nuevo)
            {
                Prestamo a = new Prestamo();
                {

                    a.Abono = txtAbonoDeuda.Text.ToUpper();
                    a.SaldoRestante = txtSaldoPendiente.Text.ToUpper();
                    a.venta = txtEmpleadoPrestamo.Text.ToUpper();
                }

                if (manejadorPrestamos.Create(a))
                {
                    MessageBox.Show("Prestamo ingresado correctamente", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasPrestamos(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Comision", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void btnEditarProducto_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditarPrestamo_Click(object sender, RoutedEventArgs e)
        {
         
            if (dtgPrestamos.SelectedItem != null)
            {
                operacion = accion.Editar;
                LimpiarEditarTablasPrestamos(true);
                Prestamo pres = dtgPrestamos.SelectedItem as Prestamo;
                txtSaldoPendiente.Text = pres.SaldoRestante;
                txtEmpleadoPrestamo.Text = pres.venta;



                txtAbonoDeuda.Text = pres.SaldoRestante;
              
             

        

         



            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Comision", "Comision", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            Prestamo pres = dtgPrestamos.SelectedItem as Prestamo;
            if (pres != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorPrestamos.Delete(pres.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorPrestamos.Delete(pres.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnCancelarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasPrestamos(false);
            }



        }







       



        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasCliente(true);
             operacion = accion.Nuevo;

        }

      

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == accion.Nuevo)
            {
                Clientes a = new Clientes();
                a.Nombre = txtNombreCliente.Text.ToUpper();
                a.ApellidoPaterno = txtApellidoPaternoCliente.Text.ToUpper();
                a.ApellidoMaterno = txtApellidoMaternoCliente.Text.ToUpper();
                a.Domicilio = txtDomicilioCliente.Text.ToUpper();
                a.Telefono = txtTelefonoCliente.Text.ToUpper();
             


                if (manejadorClientes.Create(a))
                {
                    MessageBox.Show("Cliente, ingresado correctamente", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarCamposTablasCliente(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
           
            if (dtgClientes.ItemsSource != null)
            {
                operacion = accion.Editar;
                LimpiarCamposTablasCliente(true);
                Clientes cli = dtgClientes.SelectedItem as Clientes;
                txtNombreCliente.Text= cli.Nombre;

                txtApellidoMaternoCliente.Text = cli.ApellidoMaterno;
                txtApellidoPaternoCliente.Text = cli.ApellidoPaterno;
                txtDomicilioCliente.Text = cli.ApellidoPaterno;

                txtTelefonoCliente.Text = cli.Telefono;
            



            }

            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Cliente", "Comision", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Clientes cli = dtgClientes.SelectedItem as Clientes;
            if (cli != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Comision", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorClientes.Delete(cli.Id))
                    {
                        MessageBox.Show("Distribuidor eliminado", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                        manejadorClientes.Delete(cli.Id);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Distribuidor", "Comision", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }

        private void btnCancelarCliente_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Comision", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarCamposTablasCliente(false);
            }
        }




        private void btnVideoUno_Click(object sender, RoutedEventArgs e)
        {
            VideoUno v = new VideoUno();
            v.Show();
        }

        private void btnVideoDos_Click(object sender, RoutedEventArgs e)
        {
            VideoDos V = new VideoDos();
            V.Show();
        }

      

        private void btnVideoTres_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
