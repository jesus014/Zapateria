using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Adminitracion.GUI.Contrasenia
{
    class ManejadorContrasenia
    {
        public string Archivo { get; set; }
        public ManejadorContrasenia(string archivo)
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
