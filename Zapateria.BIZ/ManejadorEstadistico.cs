using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorEstadistico : IManejadorEstadistico
    {
        IRepositorio<Estadisticos> repositorio;

        public ManejadorEstadistico(IRepositorio<Estadisticos>repo)
        {
            repositorio = repo;
        }

        public List<Estadisticos> Listar => repositorio.Read;

        public Estadisticos BuscarPorId(string id)
        {

            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Estadisticos entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Estadisticos entidad)
        {
              return repositorio.Update(entidad);
        }
    }
}
