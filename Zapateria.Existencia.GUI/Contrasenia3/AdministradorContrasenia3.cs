using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Existencia.GUI.Contrasenia3
{
    class AdministradorContrasenia3
    {
        ManejadorContrasenia3 leerArchivo;
        ManejadorContrasenia3 leerArchivo2;
        public AdministradorContrasenia3()
        {
            leerArchivo = new ManejadorContrasenia3("ContrasenaE.txt");
            leerArchivo2 = new ManejadorContrasenia3("UsuarioE.txt");
        }
        string letras;

        public string contrasena()
        {

            string datos = leerArchivo.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letras = campos[0];
                }
            }

            return letras;

        }
        string letrasUsu;
        /// <summary>
        /// Leer el usuario
        /// </summary>
        /// <returns></returns>
        public string usuario()
        {
            string datos = leerArchivo2.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letrasUsu = campos[0];
                }
            }
            return letrasUsu;

        }
    }
}
