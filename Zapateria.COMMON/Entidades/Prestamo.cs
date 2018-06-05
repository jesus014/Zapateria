using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
    public class Prestamo:Identificador
    {
        public string venta { get; set; }
        public string Abono { get; set; }
        public string SaldoRestante { get; set; }

        public override string ToString()
        {
            return venta;
        }
    }
}
