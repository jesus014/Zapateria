using System;
using System.Collections.Generic;
using System.Text;
using Zapateria.COMMON.Entidades;

namespace Zapateria.COMMON.Interfaz
{
    public interface IRepositorio<T> where T:Identificador
    {
        bool Create(T entidad);
        List<T> Read { get; }
        bool Update(T entidadModificada);
        bool Delete(string id);
    }
}
