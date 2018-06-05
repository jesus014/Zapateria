using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
    public class Clientes:Identificador
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
