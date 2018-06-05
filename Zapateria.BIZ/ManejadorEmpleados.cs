using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorEmpleados : IManejadorEmpleado
    {
        IRepositorio<Empleado> repositorio;


        public ManejadorEmpleados(IRepositorio<Empleado>repo)
        {
            repositorio = repo;
        }

        public List<Empleado> Listar => repositorio.Read;

        public Empleado BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Empleado entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public List<Empleado> Empleadoss(string Empleadoss)
        {
            return Listar.Where(e => e.Nombre == Empleadoss).ToList();
        }

        public bool Update(Empleado entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
