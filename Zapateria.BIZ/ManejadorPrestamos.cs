using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.BIZ
{
    public class ManejadorPrestamos : IManejadorPrestamo
    {
        IRepositorio<Prestamo> repositorio;
        public ManejadorPrestamos(IRepositorio<Prestamo>repo)
        {
            repositorio = repo;
        }

        public List<Prestamo> Listar => repositorio.Read;

        public Prestamo BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Create(Prestamo entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Update(Prestamo entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
