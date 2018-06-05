﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zapateria.COMMON.Entidades;
using Zapateria.COMMON.Interfaz;

namespace Zapateria.DAL
{
    public class RepositorioPrestamo : IRepositorio<Prestamo>
    {
        private string DBName = "TrabajoFinal.db";
        private string TableName = "Prestamo";


        public List<Prestamo> Read
        {
            get
            {
                List<Prestamo> datos = new List<Prestamo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Prestamo>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(Prestamo entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Prestamo>(TableName);
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
                    var coleccion = db.GetCollection<Prestamo>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Prestamo entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Prestamo>(TableName);
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
