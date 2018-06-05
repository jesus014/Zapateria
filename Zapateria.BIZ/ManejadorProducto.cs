using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorProducto : IManejadorProducto
    {
        IRepositorio<Productos> repositorio;
        public ManejadorProducto(IRepositorio<Productos>repo)
        {
            repositorio = repo;
        }

        public List<Productos> Listar => repositorio.Read;

        public Productos BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Productos entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Productos entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
