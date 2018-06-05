using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.DAL
{
    public class RepositorioEstadisticos:IRepositorio<Estadisticos>
    {
        private string DBName = "TrabajoFinal.db";
        private string TableName = "Estadisticos";

        public List<Estadisticos> Read
        {
            get
            {
                List<Estadisticos> datos = new List<Estadisticos>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Estadisticos>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(Estadisticos entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Estadisticos>(TableName);
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
                    var coleccion = db.GetCollection<Clientes>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Estadisticos entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Estadisticos>(TableName);
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
