using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.DAL
{
    public class RepositorioMarca : IRepositorio<Marca>
    {
        private string DBName = "TrabajoFinal.db";
        private string TableName = "Marca";


        public List<Marca> Read
        {
            get
            {
                List<Marca> datos = new List<Marca>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Marca>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(Marca entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Marca>(TableName);
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
                    var coleccion = db.GetCollection<Marca>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Marca entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Marca>(TableName);
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
