using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorComision : IManejadorComision
    {
        IRepositorio<Comision> repositorio;
        public ManejadorComision(IRepositorio<Comision>repo)
        {
            repositorio = repo;
        }

        public List<Comision> Listar => repositorio.Read;

        public Comision BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Comision entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Comision entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
