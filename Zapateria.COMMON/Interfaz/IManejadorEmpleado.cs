using System;
using System.Collections.Generic;
using System.Text;
using Zapateria.COMMON.Entidades;

namespace Zapateria.COMMON.Interfaz
{
    public interface IManejadorEmpleado:IManejadorGenerico<Empleado>
    {
        List<Empleado> Empleadoss(string Empleadoss);
    }
}
