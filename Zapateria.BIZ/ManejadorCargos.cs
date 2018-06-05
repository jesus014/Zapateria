using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorCargos : IManejadorCargos
    {
        IRepositorio<Cargos> repositorio;
        public ManejadorCargos(IRepositorio<Cargos>repo)
        {
            repositorio = repo;
        }

        public List<Cargos> Listar => repositorio.Read;

        public Cargos BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Cargos entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);

        }

        public bool Update(Cargos entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
