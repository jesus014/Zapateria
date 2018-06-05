using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorClientes : IManejadorClientes
    {
        IRepositorio<Clientes> repositorio;

        public ManejadorClientes(IRepositorio<Clientes>repo)
        {
            repositorio = repo;
        }

        public List<Clientes> Listar =>  repositorio.Read;

        public Clientes BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();

        }

        public bool Create(Clientes entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Clientes entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
