using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
    public class Cargos:Identificador
    {
        public string TipoCargo { get; set; }
        public string Salario { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return TipoCargo;
        }

    }
}
