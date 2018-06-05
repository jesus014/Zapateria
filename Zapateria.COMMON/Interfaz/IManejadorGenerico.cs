using System;
using System.Collections.Generic;
using System.Text;
using Zapateria.COMMON.Entidades;

namespace Zapateria.COMMON.Interfaz
{
  public   interface IManejadorGenerico<T>where T:Identificador
    {

        bool Create(T entidad);
        List<T> Listar { get; }
        bool Update(T entidad);
        bool Delete(string id);
        T BuscarPorId(string id);



    }
}
