using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
   public class Productos:Identificador
    {
        public string NombreProducto { get; set; }
        public string Estilo { get; set; }
        public string Marca { get; set; }
        public string TallaDisponible { get; set; }
        public string Cantidad { get; set; }
        public string Colores { get; set; }
        public string Proveedor { get; set; }

        public override string ToString()
        {
            return NombreProducto;
        }

    }
}
