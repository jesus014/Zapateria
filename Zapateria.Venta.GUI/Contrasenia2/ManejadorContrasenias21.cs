using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Venta.GUI.Contrasenia2
{
    class ManejadorContrasenias21
    {
        public string Archivo { get; set; }
        public ManejadorContrasenias21(string archivo)
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
