using System;
using System.Collections.Generic;
using System.Text;
using Zapateria.COMMON.Entidades;

namespace Zapateria.COMMON.Modelos
{
    public class Model
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Domicilio { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public Model(Empleado empleados)
        {
            Nombre = string.Format("{0} {1} {2} {3}", empleados.ApellidoMaterno, empleados.ApellidoPaterno,Domicilio,RFC);
         
            Telefono = empleados.Telefono;
        }
    }
}
