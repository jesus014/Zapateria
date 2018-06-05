using System;
using System.Collections.Generic;
using System.Text;

namespace Zapateria.COMMON.Entidades
{
    public class Marca:Identificador
    {
        public string marca { get; set; }
        public string Estilo { get; set; }
        public string Genero { get; set; }
        public string DescripcionMarca { get; set; }

        public override string ToString()
        {
            return Estilo;
        }
    }
}
