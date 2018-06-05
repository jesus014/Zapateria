using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorDistribuidor : IManejadorDistribuidores
    {
        IRepositorio<Distribuidores> repositorio;
        public ManejadorDistribuidor(IRepositorio<Distribuidores>repo)

        {
            repositorio = repo;
        }

        public List<Distribuidores> Listar => repositorio.Read;

        public Distribuidores BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Distribuidores entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Distribuidores entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
