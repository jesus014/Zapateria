using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.DAL
{
    public class RepositorioDistribuidores : IRepositorio<Distribuidores>
    {
        private string DBName = "TrabajoFinal.db";
        private string TableName = "Distribuidores";

        public List<Distribuidores> Read
        {
            get
            {
                List<Distribuidores> datos = new List<Distribuidores>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Distribuidores>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(Distribuidores entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Distribuidores>(TableName);
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
                    var coleccion = db.GetCollection<Distribuidores>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Distribuidores entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Distribuidores>(TableName);
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
