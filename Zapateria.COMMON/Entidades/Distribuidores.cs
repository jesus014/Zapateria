using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
   public class Distribuidores:Identificador
    {
        public string Distribuidora { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public override string ToString()
        {
            return Distribuidora;
        }
    }
}
