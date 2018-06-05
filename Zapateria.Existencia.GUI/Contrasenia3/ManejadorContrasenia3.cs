using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Existencia.GUI.Contrasenia3
{
    class ManejadorContrasenia3
    {
        public string Archivo { get; set; }
        public ManejadorContrasenia3(string archivo)
        {
            Archivo = archivo;
        }
        /// <summary>
        /// Permite leer
        /// </summary>
        /// <returns></returns>
        public string LeerA()
        {
            try
            {
                StreamReader file = new StreamReader(Archivo);
                string datos = file.ReadToEnd();
                file.Close();
                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
