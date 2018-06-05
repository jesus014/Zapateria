using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
    public class Estadisticos:Identificador
    {
        public string NombreCliente { get; set; }
        public string ProductoVenta { get; set; }
        public string Costo { get; set; }
        public override string ToString()
        {
            return ProductoVenta;
        }
    }
}
