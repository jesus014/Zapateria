using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorMarca : IManejadorMarca

    {
        IRepositorio<Marca> repositorio;

        public ManejadorMarca(IRepositorio<Marca>repo)

        {
            repositorio = repo;
        }

        public List<Marca> Listar => repositorio.Read;



        public Marca BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Marca entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Marca entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
