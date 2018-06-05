using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.DAL
{
    public class RepositorioComision : IRepositorio<Comision>

    {
        private string DBName = "TrabajoFinal.db";
        private string TableName = "Comision";

        public List<Comision> Read
        {
            get
            {
                List<Comision> datos = new List<Comision>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Comision>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(Comision entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Comision>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Comision>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Comision entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Comision>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
